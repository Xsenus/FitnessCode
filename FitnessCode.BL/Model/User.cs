using System;
using System.Collections.Generic;

namespace FitnessCode.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {

        #region Свойства

        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string  Name { get; set; }

        public int? GenderId { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Heiht { get; set; }

        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        /*
         * Реализация возраста
         * 
         * DateTime nowDate = DateTime.Today;
         * int age = nowDate.Year - birthDate.Year;
         * if (birthDate > now.Date.AddYears(-age)) age--;
         */

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="heiht">Рост.</param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double heiht)
        {
            #region Проверка условий

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentException("Пол не может быть null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен нулю.", nameof(weight));
            }

            if (heiht <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен нулю.", nameof(heiht));
            }

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Heiht = heiht;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public User() { }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
