using Dawn.Entities.System;
using System.Reflection;

namespace Dawn.Commons.Seed
{
    /// <summary>
    /// 种子数据
    /// </summary>
    public class DBSeed
    {
        private static string SeedDataFolder = "Dawn.Data.Json/{0}.tsv";

        /// <summary>
        /// 异步添加种子数据
        /// </summary>
        /// <param name="appContext"></param>
        /// <param name="WebRootPath"></param>
        /// <returns></returns>
        public static async Task SeedAsync(ApplicationDbContext appContext, string WebRootPath)
        {
            try
            {
                if (string.IsNullOrEmpty(WebRootPath))
                {
                    throw new Exception("获取wwwroot路径时，异常！");
                }

                SeedDataFolder = Path.Combine(WebRootPath, SeedDataFolder);

                Console.WriteLine("************ Dawn DataBase Set *****************");
                Console.WriteLine($"Is multi-DataBase: {AppSettings.App(new string[] { "MutiDBEnabled" })}");
                Console.WriteLine($"Is CQRS: {AppSettings.App(new string[] { "CQRSEnabled" })}");
                Console.WriteLine();
                Console.WriteLine($"Master DB ConId: {ApplicationDbContext.ConnId}");
                Console.WriteLine($"Master DB Type: {ApplicationDbContext.DbType}");
                Console.WriteLine($"Master DB ConnectString: {ApplicationDbContext.ConnectionString}");
                Console.WriteLine();
                if (AppSettings.App(new string[] { "MutiDBEnabled" }).ObjToBool())
                {
                    var slaveIndex = 0;
                    DBConfig.MutiConnectionString.allDbs.Where(x => x.ConnId != MainDb.CurrentDbConnId).ToList().ForEach(m =>
                    {
                        slaveIndex++;
                        Console.WriteLine($"Slave{slaveIndex} DB ID: {m.ConnId}");
                        Console.WriteLine($"Slave{slaveIndex} DB Type: {m.DbType}");
                        Console.WriteLine($"Slave{slaveIndex} DB ConnectString: {m.Connection}");
                        Console.WriteLine($"--------------------------------------");
                    });
                }
                else if (AppSettings.App(new string[] { "CQRSEnabled" }).ObjToBool())
                {
                    var slaveIndex = 0;
                    DBConfig.MutiConnectionString.slaveDbs.Where(x => x.ConnId != MainDb.CurrentDbConnId).ToList().ForEach(m =>
                    {
                        slaveIndex++;
                        Console.WriteLine($"Slave{slaveIndex} DB ID: {m.ConnId}");
                        Console.WriteLine($"Slave{slaveIndex} DB Type: {m.DbType}");
                        Console.WriteLine($"Slave{slaveIndex} DB ConnectString: {m.Connection}");
                        Console.WriteLine($"--------------------------------------");
                    });
                }
                else
                {
                }

                Console.WriteLine();

                // 创建数据库
                Console.WriteLine($"Create Database(The Db Id:{ApplicationDbContext.ConnId})...");

                if (ApplicationDbContext.DbType != SqlSugar.DbType.Oracle)
                {
                    appContext.Db.DbMaintenance.CreateDatabase();
                    ConsoleHelper.WriteSuccessLine($"Database created successfully!");
                }
                else
                {
                    //Oracle 数据库不支持该操作
                    ConsoleHelper.WriteSuccessLine($"Oracle 数据库不支持该操作，可手动创建Oracle数据库!");
                }

                // 创建数据库表，遍历指定命名空间下的class，
                // 注意不要把其他命名空间下的也添加进来。
                Console.WriteLine("Create Tables...");

                var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                var referencedAssemblies = Directory.GetFiles(path, "Dawn.Entities.dll").Select(Assembly.LoadFrom).ToArray();
                var entityTypes = referencedAssemblies
                    .SelectMany(a => a.DefinedTypes)
                    .Select(type => type.AsType())
                    .Where(x => x.IsClass && x.Namespace != null && x.Namespace.Equals("Dawn.Entities.System")).ToList();
                entityTypes.ForEach(t =>
                {
                    // 这里只支持添加表，不支持删除
                    // 如果想要删除，数据库直接右键删除，或者联系SqlSugar作者；
                    if (!appContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        appContext.Db.CodeFirst.InitTables(t);
                    }
                });
                ConsoleHelper.WriteSuccessLine($"Tables created successfully!");
                Console.WriteLine();

                if (AppSettings.App(new string[] { "AppSettings", "SeedDBDataEnabled" }).ObjToBool())
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;  // 日期类型默认格式化处理
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                        setting.NullValueHandling = NullValueHandling.Ignore;                 // 空值处理
                        //setting.Converters.Add(new BoolConvert("是,否"));                   // 高级用法九中的Bool类型转换 设置

                        return setting;
                    });

                    Console.WriteLine($"Seeding database data (The Db Id:{ApplicationDbContext.ConnId})...");

                    #region SysModules
                    if (!await appContext.Db.Queryable<SysModules>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysModules>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysModules"), Encoding.UTF8), setting);

                        appContext.GetEntityDB<SysModules>().InsertRange(data);
                        Console.WriteLine("Table:SysModules created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SysModules already exists...");
                    }
                    #endregion

                    #region SysAuthorize
                    if (!await appContext.Db.Queryable<SysAuthorize>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysAuthorize>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysAuthorize"), Encoding.UTF8), setting);

                        appContext.GetEntityDB<SysAuthorize>().InsertRange(data);
                        Console.WriteLine("Table:SysAuthorize created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SysAuthorize already exists...");
                    }
                    #endregion

                    #region SysRole
                    if (!await appContext.Db.Queryable<SysRole>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysRole>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysRole"), Encoding.UTF8), setting);

                        appContext.GetEntityDB<SysRole>().InsertRange(data);
                        Console.WriteLine("Table:SysRole created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SysRole already exists...");
                    }
                    #endregion

                    #region SysRoleModulesAuthorize
                    if (!await appContext.Db.Queryable<SysRoleModulesAuthorize>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysRoleModulesAuthorize>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysRoleModulesAuthorize"), Encoding.UTF8), setting);

                        appContext.GetEntityDB<SysRoleModulesAuthorize>().InsertRange(data);
                        Console.WriteLine("Table:SysRoleModulesAuthorize created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SysRoleModulesAuthorize already exists...");
                    }
                    #endregion

                    #region SysUserRole
                    if (!await appContext.Db.Queryable<SysUserRole>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysUserRole>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysUserRole"), Encoding.UTF8), setting);

                        appContext.GetEntityDB<SysUserRole>().InsertRange(data);
                        Console.WriteLine("Table:SysUserRole created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SysUserRole already exists...");
                    }
                    #endregion

                    #region SysUser
                    if (!await appContext.Db.Queryable<SysUser>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysUser>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysUser"), Encoding.UTF8), setting);

                        appContext.GetEntityDB<SysUser>().InsertRange(data);
                        Console.WriteLine("Table:SysUser created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SysUser already exists...");
                    }
                    #endregion

                    ConsoleHelper.WriteSuccessLine($"Done seeding database!");
                }

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"1、若是Mysql,查看常见问题:https://github.com/anjoy8/Blog.Core/issues/148#issue-776281770 \n" +
                    $"2、若是Oracle,查看常见问题:https://github.com/anjoy8/Blog.Core/issues/148#issuecomment-752340231 \n" +
                    "3、其他错误：" + ex.Message);
            }
        }
    }
}
