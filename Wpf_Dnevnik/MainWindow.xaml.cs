using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Wpf_Dnevnik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Show_tables();  
        }


        public void Show_tables() // Фуекция вывода информации из БД в приложение
        {
            Id_textbox.Clear(); Fio_textbox.Clear(); Group_textbox.Clear(); Data_roz_textbox.Clear();
            Id2_textbox.Clear(); Data_textbox.Clear(); Zadanie_textbox.Clear(); Ocenka_textbox.Clear();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            string ssql1 = $"SELECT TOP (1000) [name],[groupp],[data],[id] FROM [dnevnik].[dbo].[Student]"; //Зaпрос таблицы Student

            SqlCommand command = new SqlCommand(ssql1, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса вывод информации

            while (reader.Read()) //В цикле вывести всю информацию из таблици
            {

                Id_textbox.Text += (reader[3].ToString() + "\n");
                Fio_textbox.Text += (reader[0].ToString() + "\n");
                Group_textbox.Text += (reader[1].ToString() + "\n");
                Data_roz_textbox.Text += (reader[2].ToString() + "\n");

            }
            reader.Close(); // Закрываем "чтение" первой таблицы

            string sql2 = $"SELECT TOP (1000) [id],[data],[zadanie],[ocenka]FROM[dnevnik].[dbo].[Dnevnik]"; // Запрос таблицы Dnevnik
            SqlCommand command2 = new SqlCommand(sql2, conn);
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                Id2_textbox.Text += (reader2[0].ToString() + "\n");
                Data_textbox.Text += (reader2[1].ToString() + "\n");
                Zadanie_textbox.Text += (reader2[2].ToString()+"\n");
                Ocenka_textbox.Text += (reader2[3].ToString() + "\n");
            }

            reader2.Close(); // Закрываем чтение второй таблицы
        }


        private void Change_id_Click(object sender, RoutedEventArgs e) // Изменение айди студента в первой таблице
        {
            string id1 = old_id.Text; // старая информация
            string id2 = new_id.Text; // новая информация

            string ssql = $"UPDATE Student SET id = '{id2}' WHERE id = '{id1}'"; // замена: новая информации на место старой

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery(); // считаем количество изменений
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number); // выводим сообщением об успешном изменении

            old_id.Clear(); new_id.Clear();
        }

        private void Change_fio_Click(object sender, RoutedEventArgs e) // Изменение ФИО
        {
            string fio1 = old_fio.Text;
            string fio2 = new_fio.Text;

            string ssql = $"UPDATE Student SET name = '{fio2}' WHERE name = '{fio1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_fio.Clear(); new_fio.Clear();
        }

        private void Change_group_Click(object sender, RoutedEventArgs e) // Изменение группы
        {
            string group1 = old_group.Text;
            string group2 = new_group.Text;

            string ssql = $"UPDATE Student SET groupp = '{group2}' WHERE groupp = '{group1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_group.Clear(); new_group.Clear();
        }

        private void Change_data_roz_Click(object sender, RoutedEventArgs e) // Изменение даты рождения
        {
            string datar1 = old_data_roz.Text;
            string datar2 = new_data_roz.Text;

            string ssql = $"UPDATE Student SET data = '{datar2}' WHERE data = '{datar1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_data_roz.Clear(); new_data_roz.Clear();
        }

        private void Change_id2_Click(object sender, RoutedEventArgs e) // Изменение айди во второй таблице
        {
            string id1 = old_id2.Text;
            string id2 = new_id2.Text;

            string ssql = $"UPDATE Dnevnik SET id = '{id2}' WHERE id = '{id1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_id2.Clear(); new_id2.Clear();
        }

        private void Change_data_Click(object sender, RoutedEventArgs e) // Изменение даты оценки
        {
            string data1 = old_data.Text;
            string data2 = new_data.Text;

            string ssql = $"UPDATE Dnevnik SET data = '{data2}' WHERE data = '{data1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_data.Clear(); new_data.Clear();
        }

        private void Change_zadanie_Click(object sender, RoutedEventArgs e) // Изменение задания/темы за которую получена оценку
        {
            string zadanie1 = old_zadanie.Text;
            string zadanie2 = new_zadanie.Text;

            string ssql = $"UPDATE Dnevnik SET zadanie = '{zadanie2}' WHERE zadanie = '{zadanie1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_zadanie.Clear(); new_zadanie.Clear();
        }

        private void Change_ocenka_Click(object sender, RoutedEventArgs e) // Изменение оценки
        {
            string ocenka1 = old_ocenka.Text;
            string ocenka2 = new_ocenka.Text;

            string ssql = $"UPDATE Dnevnik SET ocenka = '{ocenka2}' WHERE ocenka = '{ocenka1}'";

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения*/

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nОбновлено объектов: " + number);

            old_ocenka.Clear(); new_ocenka.Clear();
        }

        private void Delete_fio_Click(object sender, RoutedEventArgs e) // Удаление по ФИО
        {
            string fio = udalit_fio.Text; 

            string ssql = $"DELETE  FROM Student  WHERE name = '{fio}'"; //ЗАпрос удалить поле 

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True"; 
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nУдалено объектов: " + number);

            udalit_fio.Clear();
        }

        private void Delete_id2_Click(object sender, RoutedEventArgs e) // Удаление по айди во второй таблице
        {
            string id2 = udalit_id2.Text; 

            string ssql = $"DELETE  FROM Dnevnik  WHERE id = '{id2}'"; //ЗАпрос удалить поле 

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True"; 
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nУдалено объектов: " + number);

            udalit_id2.Clear();
        }

        private void Add_student_Click(object sender, RoutedEventArgs e) // Добавление нового студента
        {
            int id = Convert.ToInt32(noviy_id.Text);
            string fio = noviy_fio.Text;
            string group = noviy_group.Text;
            string data_roz = noviy_data_roz.Text;

            string ssql = $"INSERT INTO Student (name,groupp,data,id) VALUES ('{fio}', '{group}','{data_roz}', '{id}')"; //ЗАпрос вставить данные в таблицу 

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True"; 
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nВставлено объектов: " + number);

            noviy_id.Clear(); noviy_fio.Clear(); noviy_group.Clear(); noviy_data_roz.Clear();
        }

        private void Add_ocenka_Click(object sender, RoutedEventArgs e) // Добавление новой оценки
        {
            int id2 = Convert.ToInt32(noviy_id2.Text);
            string data = noviy_data.Text;
            string zadanie = noviy_zadanie.Text;
            string ocenka = noviy_ocenka.Text;

            string ssql = $"INSERT INTO Dnevnik (id,data,zadanie,ocenka) VALUES ('{id2}', '{data}','{zadanie}', '{ocenka}')"; //ЗАпрос вставить данные в таблицу

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True"; 
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов

            int number = command.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!\nВставлено объектов: " + number);

            noviy_id2.Clear(); noviy_data.Clear(); noviy_zadanie.Clear(); noviy_ocenka.Clear();
        }

        private void Obnovit_tablici_Click(object sender, RoutedEventArgs e) // Обновить данные в textbox'ах
        {
            Id_textbox.Clear(); Fio_textbox.Clear(); Group_textbox.Clear(); Data_roz_textbox.Clear();
            Id2_textbox.Clear(); Data_textbox.Clear(); Zadanie_textbox.Clear(); Ocenka_textbox.Clear();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            string ssql1 = $"SELECT TOP (1000) [name],[groupp],[data],[id] FROM [dnevnik].[dbo].[Student]"; //Зaпрос таблицы Student

            SqlCommand command = new SqlCommand(ssql1, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса вывод информации

            while (reader.Read()) //В цикле вывести всю информацию из таблици
            {

                Id_textbox.Text += (reader[3].ToString() + "\n");
                Fio_textbox.Text += (reader[0].ToString() + "\n");
                Group_textbox.Text += (reader[1].ToString() + "\n");
                Data_roz_textbox.Text += (reader[2].ToString() + "\n");

            }
            reader.Close(); // Закрываем "чтение" первой таблицы

            string sql2 = $"SELECT TOP (1000) [id],[data],[zadanie],[ocenka]FROM[dnevnik].[dbo].[Dnevnik]"; // Запрос таблицы Dnevnik
            SqlCommand command2 = new SqlCommand(sql2, conn);
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                Id2_textbox.Text += (reader2[0].ToString() + "\n");
                Data_textbox.Text += (reader2[1].ToString() + "\n");
                Zadanie_textbox.Text += (reader2[2].ToString() + "\n");
                Ocenka_textbox.Text += (reader2[3].ToString() + "\n");
            }

            reader2.Close(); // Закрываем чтение второй таблицы
        }
    }
}
