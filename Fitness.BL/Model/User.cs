using System;

namespace Fitness.BL.Model
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
        /// Логин
        /// </summary>
        public string Login { get; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        #endregion

        public User(){}

        public User(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"\"{nameof(login)}\" " +
                    $"не может быть пустым или содержать только пробел.", nameof(login));
            }
            Login = login;
        }

        /// <summary>
        /// Создать новго пользователя.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string login, Gender gender, DateTime birthDate, int weight, int height)
        {
            #region Проверка на заполненность
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"\"{nameof(login)}\" " +
                    $"не может быть пустым или содержать только пробел.", nameof(login));
            }

            if (gender is null)
            {
                throw new ArgumentNullException($"\"{nameof(gender)}\" не может быть пустым.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentNullException($"Неверная дата рождения", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException($"\"{nameof(weight)}\" должен быть больше 0.", nameof(weight));
            }
            
            if (height <= 0)
            {
                throw new ArgumentNullException($"\"{nameof(height)}\" должен быть больше 0.", nameof(height));
            }

            #endregion

            Login = login;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Login +" " + BirthDate.Year;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(User))
            {
                User user = (User)obj;

                bool result = (this.Login == user.Login);

                return result;
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
