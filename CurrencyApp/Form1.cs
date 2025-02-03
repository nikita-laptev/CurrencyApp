using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CurrencyApp
{
    public partial class Form1 : Form
    {
        // ������� � �������������� ������� ����� ������������ ������� ��� (USD)
        private Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "USD", 1.0m },   // ������ ��� � ������� ������
            { "EUR", 0.85m },  // ����
            { "RUB", 90.0m },  // ���������� �����
            { "GBP", 0.75m }   // ���������� ����
        };

        public Form1()
        {
            InitializeComponent(); // ������������� ����������� �����

            // �������� �� ������� ��������� ������ � ��������� ����������
            textBoxFrom.TextChanged += textBoxFrom_TextChanged;
            comboBoxFrom.SelectedIndexChanged += comboBoxFrom_SelectedIndexChanged;
            comboBoxTo.SelectedIndexChanged += comboBoxTo_SelectedIndexChanged;
            buttonSwap.Click += buttonSwap_Click;
        }

        // ����� ���������� ��� �������� �����
        private void Form1_Load(object sender, EventArgs e)
        {
            // ��������� ���������� ������ �����
            comboBoxFrom.Items.AddRange(exchangeRates.Keys.ToArray());
            comboBoxTo.Items.AddRange(exchangeRates.Keys.ToArray());

            // ������������� ������ �� ���������
            comboBoxFrom.SelectedIndex = 0; // USD
            comboBoxTo.SelectedIndex = 1;   // EUR

            textBoxFrom.Text = "1"; // ��������� ����� ��� �����������

            UpdateConversion(); // �������� ����� ��������� �����
        }

        // ����� ��� ��������� ����� �� �����
        private void UpdateConversion()
        {
            // ���������, �������� �� �������� ����� ������
            if (decimal.TryParse(textBoxFrom.Text, out decimal amount))
            {
                // �������� ��������� ������
                string fromCurrency = comboBoxFrom.SelectedItem.ToString();
                string toCurrency = comboBoxTo.SelectedItem.ToString();

                // ������������ ����: ������� ������ / �������� ������
                decimal rate = exchangeRates[toCurrency] / exchangeRates[fromCurrency];

                // ������������� �����
                decimal result = amount * rate;

                // ������� ��������� � ��������� ���� (� ����������� �� ���� ������)
                textBoxTo.Text = result.ToString("0.##");

                // ��������� ����� �����
                labelRate.Text = $"����: 1 {fromCurrency} = {rate:0.##} {toCurrency}";
            }
            else
            {
                // ���� ������� �� �����, ������� ������
                textBoxTo.Text = "������";
            }
        }

        // ���������� ������� ��������� ������ � ���� textBoxFrom
        private void textBoxFrom_TextChanged(object sender, EventArgs e)
        {
            UpdateConversion(); // ������������� ������ ��� ��������� �����
        }

        // ���������� ������ ����� ������ � comboBoxFrom
        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConversion(); // ������������� �����
        }

        // ���������� ������ ����� ������ � comboBoxTo
        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConversion(); // ������������� �����
        }

        // ���������� ������ "�������� ������� ������"
        private void buttonSwap_Click(object sender, EventArgs e)
        {
            // ������ ������� ������� �����
            int tempIndex = comboBoxFrom.SelectedIndex;
            comboBoxFrom.SelectedIndex = comboBoxTo.SelectedIndex;
            comboBoxTo.SelectedIndex = tempIndex;

            UpdateConversion(); // ������������� ����� ����� ����� �����
        }
    }
}