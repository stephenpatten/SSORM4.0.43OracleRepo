using Funq;
using NodaTime;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Oracle;
using WebApplication5.ServiceInterface;
using WebApplication5.ServiceModel.Models;

namespace WebApplication5
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("WebApplication5", typeof(MyServices).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            LogManager.LogFactory = new DebugLogFactory();

            OracleDialect.Provider.NamingStrategy = new OrmLiteNamingStrategyBase();

            container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory(ConfigUtils.GetAppSetting("connectionString"), OracleOrmLiteDialectProvider.Instance));

            using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
            {
                db.CreateTableIfNotExists<Campaign>();
            }


            OrmLiteConfig.InsertFilter = (dbCmd, row) =>
            {
                var auditRow = row as IAudit;
                if (auditRow == null) return;
                var now = SystemClock.Instance.Now;
                var milliseconds = now.Ticks / NodaConstants.TicksPerMillisecond;
                auditRow.CreatedDate = auditRow.ModifiedDate = milliseconds;
            };
            OrmLiteConfig.UpdateFilter = (dbCmd, row) =>
            {
                var auditRow = row as IAudit;
                if (auditRow == null) return;
                var now = SystemClock.Instance.Now;
                var milliseconds = now.Ticks / NodaConstants.TicksPerMillisecond;
                auditRow.ModifiedDate = milliseconds;
            };
        }
    }
}