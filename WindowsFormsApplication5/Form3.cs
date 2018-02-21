using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form3 : Form
    {       
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string s = "";

            if (comboBox1.SelectedItem.ToString() == "да"){
                textBox1.Text = "Тест 1";
                textBox1.Text += System.Environment.NewLine +"Диагноз «Бронхиальная астма» нельзя исключить (нормальные результаты спирометрии могут быть проявлением симптома элиминации при профессиональной бронхиальной астме). "+System.Environment.NewLine+"ЕСЛИ В ФОРМЕ 1 БЫЛ ВЫБРАН П.Ф, ТО нужно провести мониторирование пиковой скорости выдоха на рабочем месте (тест №3)";
            }
            else if (comboBox1.SelectedItem.ToString() == "нет")
            {
                textBox1.Text = "Диагноз «Бронхиальная астма» возможен, нужно провести бронходилатационный тест с целью выявления степени обратимости обструкции (тест №2)";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox2.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "Диагноз «Бронхиальная астма» вероятен. Определить связь бронхиальной астмы с профессией (перейти к тестам №3, №4, ЕСЛИ В ФОРМЕ 1 БЫЛ ВЫБРАН П.Ф))";
            }
            else if (s == "нет")
            {
                textBox1.Text = "Диагноз «Бронхиальная астма» менее вероятен. Провести тесты №3, №4 (ЕСЛИ В ФОРМЕ 1 БЫЛ ВЫБРАН П.Ф). Провести дифференциальную диагностику";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox3.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» вероятен. Для подтверждения диагноза провести метахолиновый тест (тест №4)";
            }
            else if (s == "нет")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» сомнителен, для исключения профессиональной бронхиальной астмы необходимо провести метахолиновый тест (тест №4) и специфический бронхопровокационный тест (тест №5)";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox4.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» вероятен. Для подтверждения профессиональной бронхиальной астмы нужно провести специфический бронхопровокационный тест (тест №5)";
            }
            else if (s == "нет")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» сомнителен. Для исключения профессиональной бронхиальной астмы нужно провести специфический бронхопровокационный тест (тест №5)";
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox5.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "диагноз «Профессиональная бронхиальная астма» подтвержден. Определены причинные факторы (индукторов и триггеров) профессиональной астмы.";

                Form f4 = new Form4();
                f4.Show();
            }
            else if (s == "нет")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» маловероятен. Провести аллергическое, иммунологическое тестирование с производственным аллергеном (тесты №6, 7).";
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox6.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» вероятен (аллергический фенотип). Провести тест реэкспозиции (тест №8)";
            }
            else if (s == "нет")
            {
                textBox1.Text = "Отрицательный результат недостаточен для исключения профессионального генеза астмы. Провести тест реэкспозиции (тест №8)";
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox7.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» вероятен (аллергический фенотип). Провести тест реэкспозиции (тест №8)";
            }
            else if (s == "нет")
            {
                textBox1.Text = "Отрицательный результат недостаточен для исключения профессионального генеза астмы. Провести тест реэкспозиции (тест №8).";
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            s = comboBox8.SelectedItem.ToString();

            if (s == "да")
            {
                textBox1.Text = "Диагноз «Профессиональная бронхиальная астма» подтвержден";
            
                Form f4 = new Form4();
                f4.Show();
            }
            else if (s == "нет")
            {
                textBox1.Text = "Связь бронхиальной астмы с профессией не подтверждена";
            }
        }
    }
}
