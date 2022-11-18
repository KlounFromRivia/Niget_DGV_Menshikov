using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nuget_DataGridView_Menhsikov.Models;

namespace Nuget_DataGridView_Menhsikov
{
    public partial class FormTovarInfo : Form
    {
        private readonly Tovar tovars;
        public FormTovarInfo()
        {
            InitializeComponent();
            FillMaterial();
            tovars = new Tovar
            {
                Material = Material.Med,
            };
            comboBoxMaterial.SelectedItem = tovars.Material;
        }

        public FormTovarInfo(Tovar source)
            :this()
        {
            textBoxName.Text = source.TovarName;
            comboBoxMaterial.SelectedItem = source.Material;
            numericUpDownPrice.Value = Convert.ToDecimal(source.Price);
            maskedTextBoxSize.Text = source.Size;
            numericUpDownCount.Value = source.Count;
            numericUpDownMinCount.Value = source.MinCount;
        }
        public Tovar Tovar => tovars;
        private void FillMaterial()
        {
            foreach (var item in Enum.GetValues(typeof(Models.Material)))
            {
                comboBoxMaterial.Items.Add(item);
            }
        }

        private void comboBoxDayB_DrawItem(object sender, DrawItemEventArgs e)
        {
            var parent = sender as ComboBox;
            if (parent != null)
            {
                e.DrawBackground();
                Brush brush = new SolidBrush(parent.ForeColor);
                if ((e.State & DrawItemState.Selected) ==  DrawItemState.Selected)
                {
                    brush = SystemBrushes.HighlightText;
                }

                if (e.Index >= 0)
                {
                    if (parent.Items[e.Index] is Material material)
                    {
                        var text = "";
                        switch (material)
                        {
                            case Material.Med:
                                text = "Медь";
                                break;
                            case Material.Stal:
                                text = "Сталь";
                                break;
                            case Material.Iron:
                                text = "Железо";
                                break;
                            case Material.Hrom:
                                text = "Хром";
                                break;
                        }

                        e.Graphics.DrawString(
                            text,
                            parent.Font,
                            brush,
                            e.Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawString(
                            parent.Items[e.Index].ToString(),
                            parent.Font,
                            brush,
                            e.Bounds);
                    }
                }
            }
        }

        public void Validate()
        {
            buttonSave.Enabled = !string.IsNullOrEmpty(tovars.TovarName) && !string.IsNullOrEmpty(tovars.Size);
        }

        private void comboBoxMaterial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedIndex >= 0)
            {
                tovars.Material = (Material)comboBoxMaterial.SelectedItem;
            }
        }

        private void maskedTextBoxSize_TextChanged(object sender, EventArgs e)
        {
            tovars.Size = maskedTextBoxSize.Text.Trim();
            Validate();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            textBoxName.Text = textBoxName.Text.ToUpper();
            textBoxName.SelectionStart = textBoxName.Text.Length;
            tovars.TovarName = textBoxName.Text.Trim();
            Validate();
        }

        private void numericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            tovars.Count = Convert.ToInt32(numericUpDownCount.Value);
        }

        private void numericUpDownPrice_ValueChanged(object sender, EventArgs e)
        {
            tovars.Price = Convert.ToDouble(Math.Round(numericUpDownPrice.Value, 2));
        }

        private void numericUpDownMinCount_ValueChanged(object sender, EventArgs e)
        {
            tovars.MinCount = Convert.ToInt32(numericUpDownMinCount.Value);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var val = tovars.Count;
            var minVal = tovars.MinCount;
            if (numericUpDownCount.Value != 0 && numericUpDownMinCount.Value != 0 && numericUpDownPrice.Value != 0)
            {
                if (val < minVal)
                {
                    MessageBox.Show("Кол-во товаров на складе меньше, чем требуемое минимальное кол-во", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                tovars.AllPrice = tovars.Price * tovars.Count;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте, что числовые значения не равны 0", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
