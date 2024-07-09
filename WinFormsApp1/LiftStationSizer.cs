using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using LiftingStationRevitFeeder.Domain;

namespace RevitFeederUI
{
    public partial class LiftStationSizer : Form
    {
        private void AddItemsToComboBoxes(string[] items, params System.Windows.Forms.ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                comboBox.Items.AddRange(items);
            }
        }

        public LiftStationSizer()
        {
            InitializeComponent();

            string[] items = { "Select", "40", "50", "65", "80", "100", "125", "150", "200", "250", "300", "350", "400", "450", "500", "550", "600" };

            AddItemsToComboBoxes(items, comboBox1, comboBox2,
                             comboBox3, comboBox4, comboBox5,
                             comboBox6, comboBox7, comboBox8);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            comboBox7.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
            comboBox8.SelectedIndexChanged += comboBox8_SelectedIndexChanged;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            int lowerBound = 65;
            int upperBound = 500;
            if (int.TryParse(comboBox1.Text, out int dn1Value))
            {
                if (dn1Value < lowerBound)
                {
                    comboBox1.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn1Value > upperBound)
                {
                    comboBox1.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                comboBox1.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label23.ForeColor = Color.RoyalBlue;
            label24.ForeColor = Color.RoyalBlue;
            { this.comboBox2.Enabled = true; }
            { this.label21.Enabled = true; }
            { this.label22.Enabled = true; }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click_1(object sender, EventArgs e)
        {

        }

        private void label94_Click(object sender, EventArgs e)
        {

        }

        private void label95_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }
        //Flow selector
        private void label106_Click(object sender, EventArgs e)
        {
            int lowerBound = 16;
            int upperBound = 1000;
            if (int.TryParse(textBox47.Text, out int flowValue))
            {
                if (flowValue < lowerBound)
                {
                    textBox47.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m³/h and {upperBound} m³/h." +
                        $"\nValue modified to lower limit!");
                }
                else if (flowValue > upperBound)
                {
                    textBox47.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m³/h and {upperBound} m³/h." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox47.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m³/h and {upperBound} m³/h." +
                        $"\nValue modified to lower limit!");
            }
            label105.ForeColor = Color.RoyalBlue;
            label106.ForeColor = Color.RoyalBlue;
            { this.textBox27.Enabled = true; }
            { this.label103.Enabled = true; }
            { this.label104.Enabled = true; }
        }

        private void label113_Click(object sender, EventArgs e)
        {

        }

        // RESET Button
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
        }
        // Enable DimB
        //private void CheckAndEnableTextBox11()
        //{
        //    bool isComboBoxSelected = comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Select";
        //    bool isTextBox1Valid = double.TryParse(textBox1.Text, out _);
        //    bool isTextBox3Valid = double.TryParse(textBox3.Text, out _);

        //    textBox11.Enabled = isComboBoxSelected && isTextBox1Valid && isTextBox3Valid;
        //}
        // DN1 selector
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
            //if (selectedItem != "Select")
            //{ this.comboBox2.Enabled = true; }
            //else
            //{ this.comboBox2.Enabled = false; }
        }
        // DN2 selector
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox2.SelectedItem.ToString();
        }
        // DNInlet selector
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox3.SelectedItem.ToString();
        }
        // DN3 selector
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox4.SelectedItem.ToString();
        }
        // DN4 selector
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox5.SelectedItem.ToString();
        }
        // DN5 selector
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox6.SelectedItem.ToString();
        }
        // DNBreath selector
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox7.SelectedItem.ToString();
        }
        // DNBackflow selector
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox8.SelectedItem.ToString();
        }

        // DimA validator
        private void label1_Click(object sender, EventArgs e)
        {
            int lowerBound = 75;
            int upperBound = 500;
            if (int.TryParse(textBox1.Text, out int dimAValue))
            {


                if (dimAValue < lowerBound)
                {
                    textBox1.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimAValue > upperBound)
                {
                    textBox1.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox1.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label1.ForeColor = Color.RoyalBlue;
            label2.ForeColor = Color.RoyalBlue;
            { this.textBox3.Enabled = true; }
            { this.label5.Enabled = true; }
            { this.label6.Enabled = true; }
        }
        // DimB validator
        private void label4_Click(object sender, EventArgs e)
        {
            int dn1Value;
            int dimAValue = 0;
            int dimBValue;
            int dimCValue = 0;
            if (int.TryParse(comboBox1.Text, out dn1Value) && int.TryParse(textBox11.Text, out dimAValue)
                && int.TryParse(textBox11.Text, out dimBValue) && int.TryParse(textBox11.Text, out dimCValue))
            {
                int lowerBound = Convert.ToInt32(1.5 * dn1Value + dimCValue - dimAValue + 400);
                int upperBound = 3000;

                if (dimBValue < lowerBound)
                {
                    textBox11.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimBValue > upperBound)
                {
                    textBox11.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(1.5 * dn1Value + dimCValue - dimAValue + 400);
                int upperBound = 3000;
                textBox11.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label3.ForeColor = Color.RoyalBlue;
            label4.ForeColor = Color.RoyalBlue;
            { this.textBox4.Enabled = true; }
            { this.label7.Enabled = true; }
            { this.label8.Enabled = true; }
        }
        //DimA selector
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (double.TryParse(textBox1.Text, out _))
            //{ this.textBox3.Enabled = true; }
            //else
            //{ this.textBox3.Enabled = false; }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //CheckAndEnableTextBox11();
        }
        // DimC Validator
        private void label6_Click(object sender, EventArgs e)
        {
            int dn2Value;
            int dimAValue = 0;

            if (int.TryParse(comboBox2.Text, out dn2Value) && int.TryParse(textBox1.Text, out dimAValue)
            && int.TryParse(textBox3.Text, out int dimCValue))
            {
                int lowerBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 35);
                int upperBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 85);

                if (dimCValue < lowerBound)
                {
                    textBox3.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimCValue > upperBound)
                {
                    textBox3.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 35);
                int upperBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 85);
                textBox3.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label5.ForeColor = Color.RoyalBlue;
            label6.ForeColor = Color.RoyalBlue;
            { this.textBox11.Enabled = true; }
            { this.label3.Enabled = true; }
            { this.label4.Enabled = true; }
        }
        // DN2 validator
        private void label22_Click(object sender, EventArgs e)
        {
            int dn1Value;
            int dn2Value;
            string selectedValue = comboBox1.SelectedItem.ToString();
            int selectedIndex = comboBox1.SelectedIndex;
            string smallestItemAvailable = comboBox1.Items[selectedIndex - 2].ToString();
            if (int.TryParse(comboBox2.Text, out dn2Value) && int.TryParse(comboBox1.Text, out dn1Value))
            {
                int lowerBound = Math.Max(50, Convert.ToInt32(smallestItemAvailable));
                int upperBound = Math.Min(400, Convert.ToInt32(dn1Value));

                if (dn2Value < lowerBound)
                {
                    comboBox2.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn2Value > upperBound)
                {
                    comboBox2.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Math.Max(50, Convert.ToInt32(smallestItemAvailable));
                int upperBound = 400;
                comboBox2.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label22.ForeColor = Color.RoyalBlue;
            label21.ForeColor = Color.RoyalBlue;
            { this.textBox1.Enabled = true; }
            { this.label1.Enabled = true; }
            { this.label2.Enabled = true; }
        }
        // Head validator
        private void label104_Click(object sender, EventArgs e)
        {
            int lowerBound = 3;
            int upperBound = 60;
            if (int.TryParse(textBox27.Text, out int headValue))
            {
                if (headValue < lowerBound)
                {
                    textBox27.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
                }
                else if (headValue > upperBound)
                {
                    textBox27.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox27.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label103.ForeColor = Color.RoyalBlue;
            label104.ForeColor = Color.RoyalBlue;
            { this.textBox49.Enabled = true; }
            { this.label108.Enabled = true; }
            { this.label110.Enabled = true; }
        }
        // No. Duty pumps validator 
        private void label110_Click(object sender, EventArgs e)
        {
            int lowerBound = 1;
            int upperBound = 6;
            if (int.TryParse(textBox49.Text, out int headValue))
            {
                if (headValue < lowerBound)
                {
                    textBox49.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
                }
                else if (headValue > upperBound)
                {
                    textBox49.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox49.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
            }
            //label108.ForeColor = Color.RoyalBlue;
            label110.ForeColor = Color.RoyalBlue;
            { this.textBox48.Enabled = true; }
            //{ this.label108.Enabled = true; }
            { this.label107.Enabled = true; }
        }
        // No. Standby pumps validator
        private void label107_Click(object sender, EventArgs e)
        {
            int lowerBound = 1;
            int upperBound = 4;
            if (int.TryParse(textBox48.Text, out int headValue))
            {
                if (headValue < lowerBound)
                {
                    textBox48.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
                }
                else if (headValue > upperBound)
                {
                    textBox48.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox48.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
            }
            label107.ForeColor = Color.RoyalBlue;
            label108.ForeColor = Color.RoyalBlue;
            { this.comboBox3.Enabled = true; }
            { this.label54.Enabled = true; }
            { this.label93.Enabled = true; }
        }
        // DNInlet validator 
        private void label93_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox3.SelectedItem.ToString();
            if (selectedItem != "Select")
            {
                this.comboBox7.Enabled = true;
                label54.ForeColor = Color.RoyalBlue;
                label93.ForeColor = Color.RoyalBlue;
                { this.label25.Enabled = true; }
                { this.label26.Enabled = true; }
            }
            else
            { this.comboBox7.Enabled = false; }

        }
        // DnBreath validator
        private void label26_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox7.SelectedItem.ToString();
            if (selectedItem != "Select")
            {
                this.comboBox8.Enabled = true;
                label25.ForeColor = Color.RoyalBlue;
                label26.ForeColor = Color.RoyalBlue;
                { this.label47.Enabled = true; }
                { this.label48.Enabled = true; }
            }
            else
            { this.comboBox8.Enabled = false; }

        }
        // DNBackflow validator
        private void label48_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox8.SelectedItem.ToString();
            if (selectedItem != "Select")
            {
                this.comboBox1.Enabled = true;
                label47.ForeColor = Color.RoyalBlue;
                label48.ForeColor = Color.RoyalBlue;
                { this.label23.Enabled = true; }
                { this.label24.Enabled = true; }
            }
            else
            { this.comboBox1.Enabled = false; }

        }
        // DimD validator
        private void label8_Click(object sender, EventArgs e)
        {
            int dn2Value;
            int dimCValue = 0;

            if (int.TryParse(comboBox2.Text, out dn2Value) && int.TryParse(textBox3.Text, out dimCValue)
            && int.TryParse(textBox4.Text, out int dimDValue))
            {
                int lowerBound = dn2Value + dimCValue + 75;
                int upperBound = dn2Value + dimCValue + 200;

                if (dimDValue < lowerBound)
                {
                    textBox4.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimDValue > upperBound)
                {
                    textBox4.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = dn2Value + dimCValue + 75;
                int upperBound = dn2Value + dimCValue + 200;
                textBox4.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label7.ForeColor = Color.RoyalBlue;
            label8.ForeColor = Color.RoyalBlue;
            { this.textBox8.Enabled = true; }
            { this.label15.Enabled = true; }
            { this.label16.Enabled = true; }
        }
        // DimH validator
        private void label16_Click(object sender, EventArgs e)
        {
            int dn1Value;
            int lowerBound = 0;
            int upperBound = 0;

            if (int.TryParse(comboBox1.Text, out dn1Value) && int.TryParse(textBox8.Text, out int dimHValue))
            {
                if (dn1Value < 100)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 4);
                }
                else if (dn1Value < 175)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 3);
                }
                else if (dn1Value < 250)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2.5);
                }
                else
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2);
                }

                if (dn1Value < 100)
                {
                    upperBound = Convert.ToInt32(dn1Value * 6);
                }
                else if (dn1Value < 175)
                {
                    upperBound = Convert.ToInt32(dn1Value * 5);
                }
                else if (dn1Value < 250)
                {
                    upperBound = Convert.ToInt32(dn1Value * 4.5);
                }
                else
                {
                    upperBound = Convert.ToInt32(dn1Value * 4);
                }

                if (dimHValue < lowerBound)
                {
                    textBox8.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimHValue > upperBound)
                {
                    textBox8.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                if (dn1Value < 100)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 4);
                }
                else if (dn1Value < 175)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 3);
                }
                else if (dn1Value < 250)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2.5);
                }
                else
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2);
                }

                if (dn1Value < 100)
                {
                    upperBound = Convert.ToInt32(dn1Value * 6);
                }
                else if (dn1Value < 175)
                {
                    upperBound = Convert.ToInt32(dn1Value * 5);
                }
                else if (dn1Value < 250)
                {
                    upperBound = Convert.ToInt32(dn1Value * 4.5);
                }
                else
                {
                    upperBound = Convert.ToInt32(dn1Value * 4);
                }

                textBox8.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label15.ForeColor = Color.RoyalBlue;
            label16.ForeColor = Color.RoyalBlue;
            { this.textBox9.Enabled = true; }
            { this.label17.Enabled = true; }
            { this.label18.Enabled = true; }
        }
        // DimI validator
        private void label18_Click(object sender, EventArgs e)
        {
            int dimHValue = 0;

            if (int.TryParse(textBox8.Text, out dimHValue)
            && int.TryParse(textBox9.Text, out int dimIValue))
            {
                int lowerBound = Convert.ToInt32(dimHValue * 0.5);
                int upperBound = Convert.ToInt32(dimHValue * 0.75);

                if (dimIValue < lowerBound)
                {
                    textBox9.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimIValue > upperBound)
                {
                    textBox9.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dimHValue * 0.5);
                int upperBound = Convert.ToInt32(dimHValue * 0.75);
                textBox9.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label17.ForeColor = Color.RoyalBlue;
            label18.ForeColor = Color.RoyalBlue;
            { this.textBox5.Enabled = true; }
            { this.label9.Enabled = true; }
            { this.label10.Enabled = true; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        // DimE validator
        private void label10_Click(object sender, EventArgs e)
        {
            int dimIValue = 0;

            if (int.TryParse(textBox9.Text, out dimIValue)
            && int.TryParse(textBox5.Text, out int dimEValue))
            {
                int lowerBound = Convert.ToInt32(dimIValue * 1.25);
                int upperBound = Convert.ToInt32(dimIValue * 2);

                if (dimIValue < lowerBound)
                {
                    textBox5.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimIValue > upperBound)
                {
                    textBox5.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dimIValue * 1.25);
                int upperBound = Convert.ToInt32(dimIValue * 2);
                textBox5.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label9.ForeColor = Color.RoyalBlue;
            label10.ForeColor = Color.RoyalBlue;
            { this.textBox6.Enabled = true; }
            { this.label11.Enabled = true; }
            { this.label12.Enabled = true; }
        }
        // DimF validator
        private void label12_Click(object sender, EventArgs e)
        {
            double dn2Value;

            if (double.TryParse(comboBox2.Text, out dn2Value) && int.TryParse(textBox6.Text, out int dimFValue))
            {
                int lowerBound = Convert.ToInt32(Math.Round(((dn2Value + 90) / 2) / 5) * 5);
                int upperBound = 400;

                if (dimFValue < lowerBound)
                {
                    textBox6.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimFValue > upperBound)
                {
                    textBox6.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(Math.Round(((dn2Value + 90) / 2) / 5) * 5);
                int upperBound = 400;
                textBox6.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label11.ForeColor = Color.RoyalBlue;
            label12.ForeColor = Color.RoyalBlue;
            { this.textBox7.Enabled = true; }
            { this.label13.Enabled = true; }
            { this.label14.Enabled = true; }
        }
        // DimG validator
        private void label14_Click(object sender, EventArgs e)
        {
            int dn2Value;
            double dimFValue = 0;

            if (int.TryParse(comboBox2.Text, out dn2Value) && double.TryParse(textBox6.Text, out dimFValue)
                && int.TryParse(textBox7.Text, out int dimGValue))
            {
                int lowerBound = Convert.ToInt32(dimFValue / 2 + dn2Value);
                int upperBound = Convert.ToInt32(dimFValue + dn2Value * 2);

                if (dimFValue < lowerBound)
                {
                    textBox7.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimFValue > upperBound)
                {
                    textBox7.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dimFValue / 2 + dn2Value);
                int upperBound = Convert.ToInt32(dimFValue + dn2Value * 2);
                textBox7.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label13.ForeColor = Color.RoyalBlue;
            label14.ForeColor = Color.RoyalBlue;
            { this.textBox10.Enabled = true; }
            { this.label19.Enabled = true; }
            { this.label20.Enabled = true; }
        }
        // DimJ validator
        private void label20_Click(object sender, EventArgs e)
        {
            int lowerBound = 65;
            int upperBound = 200;
            if (int.TryParse(textBox10.Text, out int dimJValue))
            {


                if (dimJValue < lowerBound)
                {
                    textBox10.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimJValue > upperBound)
                {
                    textBox10.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox10.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label19.ForeColor = Color.RoyalBlue;
            label20.ForeColor = Color.RoyalBlue;
            { this.comboBox4.Enabled = true; }
            { this.label69.Enabled = true; }
            { this.label70.Enabled = true; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        // DN3 validator
        private void label70_Click(object sender, EventArgs e)
        {
            int dn2Value = 0;
            int dn3Value;
            string selectedValue = comboBox2.SelectedItem.ToString();
            int selectedIndex = comboBox2.SelectedIndex;
            string largestItemAvailable = comboBox2.Items[selectedIndex + 2].ToString();
            if (int.TryParse(comboBox4.Text, out dn3Value) && int.TryParse(comboBox2.Text, out dn2Value))
            {
                int lowerBound = Math.Max(50, Convert.ToInt32(dn2Value));
                int upperBound = Math.Min(400, Convert.ToInt32(largestItemAvailable));

                if (dn2Value < lowerBound)
                {
                    comboBox4.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn2Value > upperBound)
                {
                    comboBox4.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Math.Max(50, Convert.ToInt32(dn2Value));
                int upperBound = Math.Min(400, Convert.ToInt32(largestItemAvailable));
                comboBox4.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label69.ForeColor = Color.RoyalBlue;
            label70.ForeColor = Color.RoyalBlue;
            { this.comboBox5.Enabled = true; }
            { this.label71.Enabled = true; }
            { this.label72.Enabled = true; }
        }
        // DN4 validator
        private void label72_Click(object sender, EventArgs e)
        {
            int dn3Value = 0;
            int dn4Value;

            if (int.TryParse(comboBox5.Text, out dn4Value) && int.TryParse(comboBox4.Text, out dn3Value))
            {
                int lowerBound = dn3Value;
                int upperBound = 500;

                if (dn4Value < lowerBound)
                {
                    comboBox5.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn4Value > upperBound)
                {
                    comboBox5.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = dn3Value;
                int upperBound = 500;
                comboBox5.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label71.ForeColor = Color.RoyalBlue;
            label72.ForeColor = Color.RoyalBlue;
            { this.comboBox6.Enabled = true; }
            { this.label87.Enabled = true; }
            { this.label88.Enabled = true; }
        }
        // DN5 validator
        private void label88_Click(object sender, EventArgs e)
        {
            int dn4Value = 0;
            int dn5Value;
            string selectedValue = comboBox5.SelectedItem.ToString();
            int selectedIndex = comboBox5.SelectedIndex;
            string smallestItemAvailable = comboBox5.Items[selectedIndex - 2].ToString();
            if (int.TryParse(comboBox6.Text, out dn5Value) && int.TryParse(comboBox5.Text, out dn4Value))
            {
                int lowerBound = Convert.ToInt32(smallestItemAvailable);
                int upperBound = dn4Value;

                if (dn5Value < lowerBound)
                {
                    comboBox6.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn5Value > upperBound)
                {
                    comboBox6.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(smallestItemAvailable);
                int upperBound = dn4Value;
                comboBox6.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label87.ForeColor = Color.RoyalBlue;
            label88.ForeColor = Color.RoyalBlue;
            { this.textBox43.Enabled = true; }
            { this.label85.Enabled = true; }
            { this.label86.Enabled = true; }
        }
        // DimK validator
        private void label86_Click(object sender, EventArgs e)
        {
            int lowerBound = 500;
            int upperBound = 3000;
            if (int.TryParse(textBox43.Text, out int dimKValue))
            {


                if (dimKValue < lowerBound)
                {
                    textBox43.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimKValue > upperBound)
                {
                    textBox43.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox43.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label85.ForeColor = Color.RoyalBlue;
            label86.ForeColor = Color.RoyalBlue;
            { this.textBox42.Enabled = true; }
            { this.label83.Enabled = true; }
            { this.label84.Enabled = true; }
        }
        // DimL validator
        private void label84_Click(object sender, EventArgs e)
        {
            int lowerBound = 500;
            int upperBound = 1500;
            if (int.TryParse(textBox42.Text, out int dimLValue))
            {


                if (dimLValue < lowerBound)
                {
                    textBox42.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimLValue > upperBound)
                {
                    textBox42.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox42.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label83.ForeColor = Color.RoyalBlue;
            label84.ForeColor = Color.RoyalBlue;
            { this.textBox41.Enabled = true; }
            { this.label81.Enabled = true; }
            { this.label82.Enabled = true; }
        }
        // DimM validator
        private void label82_Click(object sender, EventArgs e)
        {
            double dn3Value;

            if (double.TryParse(comboBox3.Text, out dn3Value) && int.TryParse(textBox41.Text, out int dimMValue))
            {
                int lowerBound = Convert.ToInt32(dn3Value * 1.5);
                int upperBound = 1500;

                if (dimMValue < lowerBound)
                {
                    textBox41.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimMValue > upperBound)
                {
                    textBox41.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dn3Value * 1.5);
                int upperBound = 1500;
                textBox41.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label81.ForeColor = Color.RoyalBlue;
            label82.ForeColor = Color.RoyalBlue;
            { this.textBox40.Enabled = true; }
            { this.label79.Enabled = true; }
            { this.label80.Enabled = true; }
        }
        // DimN validator
        private void label80_Click(object sender, EventArgs e)
        {
            int lowerBound = 500;
            int upperBound = 3000;
            if (int.TryParse(textBox40.Text, out int dimNValue))
            {


                if (dimNValue < lowerBound)
                {
                    textBox40.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimNValue > upperBound)
                {
                    textBox40.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                textBox40.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label79.ForeColor = Color.RoyalBlue;
            label80.ForeColor = Color.RoyalBlue;
            { this.textBox39.Enabled = true; }
            { this.label77.Enabled = true; }
            { this.label78.Enabled = true; }
        }
        // DimO validator
        private void label76_Click(object sender, EventArgs e)
        {
            double dn3Value;
            int lowerBound = 0;
            int upperBound = 0;

            if (double.TryParse(comboBox3.Text, out dn3Value) && int.TryParse(textBox39.Text, out int dimOValue))
            {
                //DN3.Value < 80 ? new Length(500 + Math.Ceiling(DN3.Value / 4) * 10, "mm")
                //: DN3.Value < 125 ? new Length(500 + Math.Ceiling(DN3.Value / 6) * 10, "mm")
                //     : new Length(500 + Math.Ceiling(DN3.Value / 7) * 10, "mm")
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                if (dimOValue < lowerBound)
                {
                    textBox39.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimOValue > upperBound)
                {
                    textBox39.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                textBox39.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label77.ForeColor = Color.RoyalBlue;
            label78.ForeColor = Color.RoyalBlue;
            { this.textBox38.Enabled = true; }
            { this.label75.Enabled = true; }
            { this.label76.Enabled = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var designPeakHourFlow = new VolumetricFlow(Convert.ToDouble(textBox47.Text));
            var head = new Length(Convert.ToDouble(textBox27.Text));
            var dutyPumpsCount = Convert.ToInt32(textBox49.Text);
            var standbyPumpsCount = Convert.ToInt32(textBox48.Text);
            var numberOfPumps = dutyPumpsCount + standbyPumpsCount;
            var revitFeed = new RevitFeederDTO(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, numberOfPumps);
            WriteToJsonFile<RevitFeederDTO>("C:\\RevitTest\\Kutya.json", revitFeed);

        }
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
