using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using HospitalManagementSystem.Mapping;


namespace HospitalManagementSystem
{
    public static class NhibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFatory();
                }
                return _sessionFactory;
            }
        }
        public static void InitializeSessionFatory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\JANUARIUS NJOKU\Documents\testhospital.mdf"";Integrated Security=True;Connect Timeout=30")
                .ShowSql()
                )
                .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<HospitalMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, true))
                .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}