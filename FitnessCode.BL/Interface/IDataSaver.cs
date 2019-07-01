using System.Collections.Generic;

namespace FitnessCode.BL.Interface
{
    public interface IDataSaver
    {
        /// <summary>
        /// Сохранение коллекции элементов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void Save<T>(List<T> item) where T : class;

        /// <summary>
        /// Загрузка коллекции элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Коллекцию элементов</returns>
        List<T> Load<T>() where T : class;
    }
}
