using FitnessCode.BL.Interface;
using System.Collections.Generic;

namespace FitnessCode.BL.Controller
{
    public class BaseController
    {
        private readonly IDataSaver manager = new DatabaseSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        //protected void Save<T>(List<T> item, IDataSaver dataSaver) where T : class
        //{
        //    dataSaver.Save(item);

        //    manager.Save(item);
        //}

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
