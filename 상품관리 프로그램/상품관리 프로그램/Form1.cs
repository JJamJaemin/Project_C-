using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 상품관리_프로그램
{
    public partial class Form1 : Form
    {
        public int Sum;
        
        public Form1()
        {

            InitializeComponent();
                 
            dataGridView1.DataSource = Noodle.NoodleList;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
                                    
            dataGridView2.DataSource = Vegetable.VegetableList;
            dataGridView2.CurrentCellChanged += dataGridView2_CurrentCellChanged;
                        
            dataGridView3.DataSource = Snack.SnackList;
            dataGridView3.CurrentCellChanged += dataGridView3_CurrentCellChanged;
        }

        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Snack snack_selected = dataGridView3.CurrentRow.DataBoundItem as Snack;
                textBox30.Text = snack_selected.Id;
                textBox29.Text = string.Format("{0}",snack_selected.InDate);
                textBox28.Text = snack_selected.Name;
                textBox27.Text = string.Format("{0}",snack_selected.Price);
                textBox26.Text = string.Format("{0}",snack_selected.Stock);

                if (snack_selected.Stock == 0)
                {
                    snack_selected.isSoldOut = true;
                    checkBox3.Checked = true;
                }
                else
                {
                    snack_selected.isSoldOut = false;
                    checkBox3.Checked = false;
                }

            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Vegetable vegetable_selected = dataGridView2.CurrentRow.DataBoundItem as Vegetable;
                textBox10.Text = vegetable_selected.Id;
                textBox9.Text = string.Format("{0}",vegetable_selected.InDate);
                textBox8.Text = vegetable_selected.Name;
                textBox7.Text = string.Format("{0}",vegetable_selected.Price);
                textBox6.Text = string.Format("{0}",vegetable_selected.Stock);

                if (vegetable_selected.Stock == 0)
                {
                    vegetable_selected.isSoldOut = true;
                    checkBox2.Checked = true;
                }
                else
                {
                    vegetable_selected.isSoldOut = false;
                    checkBox2.Checked = false;
                }

            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Noodle noodle_selected = dataGridView1.CurrentRow.DataBoundItem as Noodle;
                textBox1.Text = noodle_selected.Id;
                textBox2.Text = string.Format("{0}",noodle_selected.InDate);
                textBox3.Text = noodle_selected.Name;
                textBox4.Text = string.Format("{0}",noodle_selected.Price);
                textBox5.Text = string.Format("{0}",noodle_selected.Stock);

                if (noodle_selected.Stock == 0)
                {
                    noodle_selected.isSoldOut = true;
                    checkBox1.Checked = true;
                }
                else
                {
                    noodle_selected.isSoldOut = false;
                    checkBox1.Checked = false;
                }

            }
            catch(Exception)
            {

            }
        }

        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //3번째 탭 추가하기 버튼
        {
            try
            {
                if(Noodle.NoodleList.Exists((x) => x.Name == textBox3.Text))
                {
                    MessageBox.Show("이미 존재하는 상품입니다.");

                }
                else
                {
                    Noodle noodle_add = new Noodle()
                    {
                        Id = textBox1.Text,
                        InDate = DateTime.Parse(textBox2.Text),
                        Name = textBox3.Text,
                        Price = int.Parse(textBox4.Text),
                        Stock = int.Parse(textBox5.Text)
                    };
                    Noodle.NoodleList.Add(noodle_add);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Noodle.NoodleList;
                    if (noodle_add.Stock == 0)
                    {
                        noodle_add.isSoldOut = true;
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        noodle_add.isSoldOut = false;
                        checkBox1.Checked = false;
                    }
                    Noodle.Save();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("상품추가중 예외발생");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Noodle noodle_edit = Noodle.NoodleList.Single((x) => x.Name == textBox3.Text);
                noodle_edit.Id = textBox1.Text;
                noodle_edit.InDate = DateTime.Parse(textBox2.Text);
                noodle_edit.Name = textBox3.Text;
                noodle_edit.Price = int.Parse(textBox4.Text);
                noodle_edit.Stock = int.Parse(textBox5.Text);
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Noodle.NoodleList;
                if(noodle_edit.Stock == 0)
                {
                    noodle_edit.isSoldOut = true;
                    checkBox1.Checked = true;
                }
                else
                {
                    noodle_edit.isSoldOut = false;
                    checkBox1.Checked = false;
                }

                /*if(checkBox1.Checked)
                {
                    noodle_edit.isSoldOut = true;
                    noodle_edit.Stock = 0;
                }
                else
                {
                    noodle_edit.isSoldOut = false;
                }*/

                Noodle.Save();
            }
            catch(Exception)
            {
                MessageBox.Show("존재하지 않는 상품입니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Noodle noodle_remove = Noodle.NoodleList.Single((x) => x.Name == textBox3.Text);
                Noodle.NoodleList.Remove(noodle_remove);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Noodle.NoodleList;
                Noodle.Save();
            }
            catch
            {
                MessageBox.Show("존재하지 않는 상품입니다.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vegetable.VegetableList.Exists((x) => x.Name == textBox8.Text))
                {
                    MessageBox.Show("이미 존재하는 상품입니다.");

                }
                else
                {
                    Vegetable vegetable_add = new Vegetable()
                    {
                        Id = textBox10.Text,
                        InDate = DateTime.Parse(textBox9.Text),
                        Name = textBox8.Text,
                        Price = int.Parse(textBox7.Text),
                        Stock = int.Parse(textBox6.Text)
                    };
                    Vegetable.VegetableList.Add(vegetable_add);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = Vegetable.VegetableList;
                    Vegetable.Save();

                    if (vegetable_add.Stock == 0)
                    {
                        vegetable_add.isSoldOut = true;
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        vegetable_add.isSoldOut = false;
                        checkBox2.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("상품추가중 예외발생");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Vegetable vegetable_edit = Vegetable.VegetableList.Single((x) => x.Name == textBox8.Text);
                vegetable_edit.Id = textBox10.Text;
                vegetable_edit.InDate = DateTime.Parse(textBox9.Text);
                vegetable_edit.Name = textBox8.Text;
                vegetable_edit.Price = int.Parse(textBox7.Text);
                vegetable_edit.Stock = int.Parse(textBox6.Text);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = Vegetable.VegetableList;
                Vegetable.Save();

                if (vegetable_edit.Stock == 0)
                {
                    vegetable_edit.isSoldOut = true;
                    checkBox2.Checked = true;
                }
                else
                {
                    vegetable_edit.isSoldOut = false;
                    checkBox2.Checked = false;
                }
                
                /*if (checkBox2.Checked)
                {
                    vegetable_edit.isSoldOut = true;
                    vegetable_edit.Stock = 0;

                }
                else
                {
                    vegetable_edit.isSoldOut = false;
                }*/
                
            }
            catch (Exception)
            {
                MessageBox.Show("존재하지 않는 상품입니다.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Vegetable vegetable_remove = Vegetable.VegetableList.Single((x) => x.Name == textBox8.Text);
                Vegetable.VegetableList.Remove(vegetable_remove);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = Vegetable.VegetableList;
                Vegetable.Save();
            }
            catch
            {
                MessageBox.Show("존재하지 않는 상품입니다.");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (Snack.SnackList.Exists((x) => x.Name == textBox28.Text))
                {
                    MessageBox.Show("이미 존재하는 상품입니다.");

                }
                else
                {
                    Snack snack_add = new Snack()
                    {
                        Id = textBox30.Text,
                        InDate = DateTime.Parse(textBox29.Text),
                        Name = textBox28.Text,
                        Price = int.Parse(textBox27.Text),
                        Stock = int.Parse(textBox26.Text)
                    };
                    Snack.SnackList.Add(snack_add);
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = Snack.SnackList;
                    if (snack_add.Stock == 0)
                    {
                        snack_add.isSoldOut = true;
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        snack_add.isSoldOut = false;
                        checkBox3.Checked = false;
                    }
                    Snack.Save();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("상품추가중 예외발생");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Snack snack_edit = Snack.SnackList.Single((x) => x.Name == textBox28.Text);
                snack_edit.Id = textBox30.Text;
                snack_edit.InDate = DateTime.Parse(textBox29.Text);
                snack_edit.Name = textBox28.Text;
                snack_edit.Price = int.Parse(textBox27.Text);
                snack_edit.Stock = int.Parse(textBox26.Text);

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = Snack.SnackList;
                if(snack_edit.Stock ==0 )
                {
                    snack_edit.isSoldOut = true;
                    checkBox3.Checked = true;
                }
                else
                {
                    snack_edit.isSoldOut = false;
                    checkBox3.Checked = false;
                }

                /*if(checkBox3.Checked)
                {
                    snack_edit.isSoldOut = true;
                    snack_edit.Stock = 0;
                }
                else
                {
                    snack_edit.isSoldOut = false;
                }*/

                Snack.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("존재하지 않는 상품입니다.");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                Snack snack_remove = Snack.SnackList.Single((x) => x.Name == textBox28.Text);
                Snack.SnackList.Remove(snack_remove);

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = Snack.SnackList;
                Snack.Save();
            }
            catch
            {
                MessageBox.Show("존재하지 않는 상품입니다.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int priceMin = int.Parse(textBox19.Text);
                int priceMax = int.Parse(textBox18.Text);
                int stockNum = int.Parse(textBox17.Text);
                DateTime indateNum = DateTime.Parse(textBox16.Text);
                var product = from item in Vegetable.VegetableList
                              where item.Price >= priceMin && item.Price <= priceMax
                              where item.Stock <= stockNum
                              where item.InDate <= indateNum
                              select item;
                List<Vegetable> vegetable_Filtered = new List<Vegetable>();
                foreach (var item in product)
                    vegetable_Filtered.Add(item as Vegetable);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = vegetable_Filtered;



            }
            catch(Exception)
            {
                MessageBox.Show("숫자를 입력해주세요");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Vegetable.VegetableList;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int priceMin = int.Parse(textBox24.Text);
                int priceMax = int.Parse(textBox23.Text);
                int stockNum = int.Parse(textBox22.Text);
                DateTime datetimeNum = DateTime.Parse(textBox21.Text);

                var product = from item in Snack.SnackList
                              where item.Price >= priceMin && item.Price <= priceMax
                              where item.Stock <= stockNum
                              where item.InDate <= datetimeNum
                              select item;
                List<Snack> snack_Filtered = new List<Snack>();
                foreach (var item in product)
                    snack_Filtered.Add(item as Snack);

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = snack_Filtered;



            }
            catch (Exception)
            {
                MessageBox.Show("숫자를 입력해주세요");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Snack.SnackList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int priceMin = int.Parse(textBox12.Text);
                int priceMax = int.Parse(textBox13.Text);
                int stockNum = int.Parse(textBox14.Text);
                DateTime indateNum = DateTime.Parse(textBox15.Text);

                var product = from item in Noodle.NoodleList
                              where item.Price >= priceMin && item.Price <= priceMax
                              where item.Stock <= stockNum
                              where item.InDate <= indateNum
                              select item;
                List<Noodle> noodle_Filtered = new List<Noodle>();
                foreach (var item in product)
                    noodle_Filtered.Add(item as Noodle);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = noodle_Filtered;



            }
            catch (Exception)
            {
                MessageBox.Show("숫자를 입력해주세요");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Noodle.NoodleList;
        }

        private void button12_Click(object sender, EventArgs e)//담기
        {
            try
            {
                
                Vegetable vegetable_shop = Vegetable.VegetableList.Single((x) => x.Name == textBox8.Text);
                vegetable_shop.Id = textBox10.Text;
                
                vegetable_shop.Name = textBox8.Text;
                vegetable_shop.Price = int.Parse(textBox7.Text);
                vegetable_shop.Stock = int.Parse(textBox6.Text);
                vegetable_shop.InDate = DateTime.Parse(textBox9.Text);
                var Num = int.Parse(textBox20.Text);
                if (vegetable_shop.Stock - Num >= 0)
                {
                    vegetable_shop.Stock = vegetable_shop.Stock - Num;
                    textBox31.Text += "[" + vegetable_shop.Id + "]" + vegetable_shop.Name + vegetable_shop.Price + "(" + Num + ")\r\n";
                    Sum += vegetable_shop.Price * Num;
                    
                }
                else
                {
                    MessageBox.Show("수량이 부족합니다.");
                }
                if(vegetable_shop.Stock==0)
                {
                    vegetable_shop.isSoldOut = true;
                    checkBox2.Checked = true;
                }
                

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = Vegetable.VegetableList;

            }
            catch(Exception)
            {
                MessageBox.Show("장바구니 예외처리 입니다.");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                
                Snack snack_shop = Snack.SnackList.Single((x) => x.Name == textBox28.Text);
                snack_shop.Id = textBox30.Text;

                snack_shop.Name = textBox28.Text;
                snack_shop.Price = int.Parse(textBox27.Text);
                snack_shop.Stock = int.Parse(textBox26.Text);
                snack_shop.InDate = DateTime.Parse(textBox29.Text);
                var Num = int.Parse(textBox25.Text);
                if (snack_shop.Stock - Num >= 0)
                {
                    snack_shop.Stock = snack_shop.Stock - Num;
                    textBox31.Text += "[" + snack_shop.Id + "]" + snack_shop.Name + snack_shop.Price + "(" + Num + ")\r\n";
                    Sum += snack_shop.Price*Num;
                }
                else
                {
                    MessageBox.Show("수량이 부족합니다.");
                }
                if (snack_shop.Stock == 0)
                {
                    snack_shop.isSoldOut = true;
                }
                

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = Snack.SnackList;

            }
            catch (Exception)
            {
                MessageBox.Show("장바구니 예외처리 입니다.");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                Noodle noodle_shop = Noodle.NoodleList.Single((x) => x.Name == textBox3.Text);
                noodle_shop.Id = textBox1.Text;

                noodle_shop.Name = textBox3.Text;
                noodle_shop.Price = int.Parse(textBox4.Text);
                noodle_shop.Stock = int.Parse(textBox5.Text);
                noodle_shop.InDate = DateTime.Parse(textBox2.Text);
                var Num = int.Parse(textBox11.Text);
                if (noodle_shop.Stock - Num >= 0)
                {
                    noodle_shop.Stock = noodle_shop.Stock - Num;
                    textBox31.Text += "[" + noodle_shop.Id + "]" + noodle_shop.Name + noodle_shop.Price + "(" + Num + ")\r\n";
                    Sum += noodle_shop.Price * Num;
                }
                else
                {
                    MessageBox.Show("수량이 부족합니다.");
                }
                if (noodle_shop.Stock == 0)
                {
                    noodle_shop.isSoldOut = true;
                }
                

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Noodle.NoodleList;

            }
            catch (Exception)
            {
                MessageBox.Show("장바구니 예외처리 입니다.");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("총 가격은" + Sum + "원 입니다.");
        }
    }
}
