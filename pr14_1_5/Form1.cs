using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pr14_1_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        Stack<int> stack = new Stack<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            
            int n = Convert.ToInt32(numericUpDown1.Text);
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    stack.Push(i);
                }
                label2.Text = $"Размерность стека {stack.Count()}";
                label3.Text = $"Верхний элемент стека = {stack.Peek()}";
                label4.Text = $"Размерность стека {stack.Count()}";
                label5.Text = $"Содержимое стека";
                while (stack.Count > 0) listBox1.Items.Add(stack.Pop());
                label6.Text = $"Новая размерность стека {stack.Count()}";
            }
            else MessageBox.Show("Число должно быть больше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        Queue<int> queue = new Queue<int>();
        private void button2_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDown2.Text);
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    queue.Enqueue(i);
                }
                label11.Text = $"Размерность стека {queue.Count()}";
                label10.Text = $"Верхний элемент стека = {queue.Peek()}";
                label9.Text = $"Размерность стека {queue.Count()}";
                label8.Text = $"Содержимое стека";
                while (queue.Count > 0) listBox1.Items.Add(queue.Dequeue());
                label7.Text = $"Новая размерность стека {queue.Count()}";
            }
            else MessageBox.Show("Число должно быть больше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Stack<char> stack1 = new Stack<char>();
            try
            {
                if (textBox1.Text != "") 
                {
                    string str = textBox1.Text;
                    foreach (char c in str)
                    {
                        if (c == '(')
                        {
                            stack1.Push(c);
                        }
                        else if (c == ')')
                        {
                            if (stack1.Count > 0 && stack1.Peek() == '(') stack1.Pop();
                            else stack1.Push(c);
                        }
                    }
                    string new_str = str;
                    while (stack1.Count > 0)
                    {
                        if (stack1.Peek() == '(')
                        {
                            new_str += ')';
                            stack1.Pop();
                        }
                        else
                        {
                            new_str = new_str.Remove(new_str.LastIndexOf('('), 1);
                        }
                    }
                    File.WriteAllText("t1.txt", new_str);
                    label17.Text = new_str;
                }
            }
            catch(FormatException) { MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }        
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stack<char> stack1 = new Stack<char>();
            string str = textBox1.Text;
            bool b = true;
            int countl = 0, countp = 0;
            for(int i = 0; i< str.Length; i++)
            {
                stack1.Push(str[i]);
                char c = str[i];
                if (stack1.Peek() != '0' && stack1.Peek() != '1' && stack1.Peek() != '2' && stack1.Peek() != '3' && stack1.Peek() != '4' && stack1.Peek() != '5' && stack1.Peek() != '6' && stack1.Peek() != '7' && stack1.Peek() != '8' && stack1.Peek() != '9' && stack1.Peek() != '*' && stack1.Peek() != '/' && stack1.Peek() != '-' && stack1.Peek() != '+' && stack1.Peek() != '(' && stack1.Peek() != ')') 
                    b = false;
                if (stack1.Peek() == ')')
                    countp++;
                if (stack1.Peek() == '(')
                    countl++;
            }
            if (b == true && countl == countp)
            {
                label16.Text = "Скобки сбалансированы";
                StreamWriter sw = File.CreateText("t.txt");
                sw.WriteLine(str);
                sw.Close();
            }
            else if (countl > countp) label16.Text = $"Лишняя ( на {str.IndexOf("(") + 1} позиции";
            else if (countl < countp) label16.Text = $"Лишняя ) на {str.IndexOf(")") + 1} позиции";
            else MessageBox.Show("Данные введены не верно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        Queue<Person> pers = new Queue<Person>();
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("1.txt"))
            {
                string[] str = File.ReadAllLines("1.txt");
                foreach (string str1 in str) 
                {
                    string[] s = str1.Split();
                    Person person1 = new Person(s[0], s[1], s[2], int.Parse(s[3]), int.Parse(s[4]));
                    pers.Enqueue(person1);
                }
                var result = from t in pers where t.age < 40 select t;
                foreach (var item in result)
                    listBox3.Items.Add($"{item.sname} {item.name} {item.otc} {item.age} {item.ves}");
                result = from t in pers where t.age > 40 select t;
                foreach (var item in result)
                    listBox3.Items.Add($"{item.sname} {item.name} {item.otc} {item.age} {item.ves}"); 
                    
                
            }
            else MessageBox.Show("Файла нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        Queue<Person> pers1 = new Queue<Person>();
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("1.txt"))
            {
                string[] FIO = File.ReadAllLines("2.txt");
                string[] dannue = File.ReadAllLines("3.txt");
                if (FIO.Length == dannue.Length) 
                {
                    for (int i = 0; i < FIO.Length; i++)
                    {
                       string[] s = FIO[i].Split();
                         string[] d = dannue[i].Split();
                        Person person1 = new Person
                        {
                            sname = s[0],
                            name = s[1],
                            otc = s[2],
                            age = int.Parse(d[0]),
                            ves = int.Parse(d[1])
                        };
                        pers1.Enqueue(person1);
                    } 
                }
                pers1.GroupBy()
                var result = from t in pers1 orderby t.age select t;
                                var results = from t in pers1 join t on t.sname ;
                foreach (var company in results)
                {
                    listBox4.Items.Add(company.Key);
                    foreach (var person in company)
                    {
                        listBox4.Items.Add($"{person.sname} {person.name} {person.otc} {person.age} {person.ves}");
                    }
                    listBox4.Items.Add("\n");
                }
            }
            else MessageBox.Show("Файла нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
