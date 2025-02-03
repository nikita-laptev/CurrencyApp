using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CurrencyApp
{
    public partial class Form1 : Form
    {
        // Словарь с фиксированными курсами валют относительно доллара США (USD)
        private Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "USD", 1.0m },   // Доллар США – базовая валюта
            { "EUR", 0.85m },  // Евро
            { "RUB", 90.0m },  // Российский рубль
            { "GBP", 0.75m }   // Британский фунт
        };

        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы

            // Подписка на события изменения данных в элементах управления
            textBoxFrom.TextChanged += textBoxFrom_TextChanged;
            comboBoxFrom.SelectedIndexChanged += comboBoxFrom_SelectedIndexChanged;
            comboBoxTo.SelectedIndexChanged += comboBoxTo_SelectedIndexChanged;
            buttonSwap.Click += buttonSwap_Click;
        }

        // Метод вызывается при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполняем выпадающие списки валют
            comboBoxFrom.Items.AddRange(exchangeRates.Keys.ToArray());
            comboBoxTo.Items.AddRange(exchangeRates.Keys.ToArray());

            // Устанавливаем валюты по умолчанию
            comboBoxFrom.SelectedIndex = 0; // USD
            comboBoxTo.SelectedIndex = 1;   // EUR

            textBoxFrom.Text = "1"; // Начальная сумма для конвертации

            UpdateConversion(); // Вызываем метод пересчёта валют
        }

        // Метод для пересчёта валют по курсу
        private void UpdateConversion()
        {
            // Проверяем, является ли введённый текст числом
            if (decimal.TryParse(textBoxFrom.Text, out decimal amount))
            {
                // Получаем выбранные валюты
                string fromCurrency = comboBoxFrom.SelectedItem.ToString();
                string toCurrency = comboBoxTo.SelectedItem.ToString();

                // Рассчитываем курс: целевая валюта / исходная валюта
                decimal rate = exchangeRates[toCurrency] / exchangeRates[fromCurrency];

                // Пересчитываем сумму
                decimal result = amount * rate;

                // Выводим результат в текстовое поле (с округлением до двух знаков)
                textBoxTo.Text = result.ToString("0.##");

                // Обновляем метку курса
                labelRate.Text = $"Курс: 1 {fromCurrency} = {rate:0.##} {toCurrency}";
            }
            else
            {
                // Если введено не число, выводим ошибку
                textBoxTo.Text = "Ошибка";
            }
        }

        // Обработчик события изменения текста в поле textBoxFrom
        private void textBoxFrom_TextChanged(object sender, EventArgs e)
        {
            UpdateConversion(); // Пересчитываем валюту при изменении ввода
        }

        // Обработчик выбора новой валюты в comboBoxFrom
        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConversion(); // Пересчитываем сумму
        }

        // Обработчик выбора новой валюты в comboBoxTo
        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConversion(); // Пересчитываем сумму
        }

        // Обработчик кнопки "Поменять местами валюты"
        private void buttonSwap_Click(object sender, EventArgs e)
        {
            // Меняем местами индексы валют
            int tempIndex = comboBoxFrom.SelectedIndex;
            comboBoxFrom.SelectedIndex = comboBoxTo.SelectedIndex;
            comboBoxTo.SelectedIndex = tempIndex;

            UpdateConversion(); // Пересчитываем сумму после смены валют
        }
    }
}