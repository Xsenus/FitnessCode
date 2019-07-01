using System;
using System.Collections.Generic;

namespace FitnessCode.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя поля не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public Gender() { }

        public override string ToString()
        {
            return Name;
        }

    }
}