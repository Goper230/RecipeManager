using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tabPage1.Dock = DockStyle.Fill;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            // Открытие выделенного рецепта
            if (listBoxRecipes.SelectedItem != null)
            {
                string selectedRecipe = listBoxRecipes.SelectedItem.ToString();
                MessageBox.Show($"Открытие рецепта: {selectedRecipe}", "Рецепт", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Создаем новую вкладку
                TabPage tabPage = new TabPage(selectedRecipe);

                // Добавляем TextBox для cook
                TextBox cook = new TextBox();
                cook.Multiline = true;
                cook.Location = new System.Drawing.Point(64, 123);
                cook.Size = new System.Drawing.Size(464, 490);
                cook.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;


                // Добавляем TextBox для ingredients
                TextBox ingredients = new TextBox();
                ingredients.Multiline = true;
                ingredients.Location = new System.Drawing.Point(702, 41);
                ingredients.Size = new System.Drawing.Size(296, 576);
                ingredients.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right;

                // Добавляем TextBox для recipeName
                TextBox recipeName = new TextBox();
                recipeName.Multiline = false;
                recipeName.Location = new System.Drawing.Point(240, 30);
                recipeName.Size = new System.Drawing.Size(381, 37);
                recipeName.Anchor = AnchorStyles.Top;

                // Создаем и настраиваем Label для cook
                Label NameLabel = new Label();
                NameLabel.Text = "Как готовить";
                NameLabel.AutoSize = true; // Чтобы метка автоматически подстраивалась под текст
                NameLabel.Font = new Font(NameLabel.Font.FontFamily, 14, FontStyle.Bold);
                NameLabel.Anchor = AnchorStyles.Top;
                // Рассчитываем позицию Label над TextBox cook по центру
                int labelX = cook.Location.X + (cook.Width - NameLabel.PreferredWidth) / 2;
                int labelY = cook.Location.Y - NameLabel.PreferredHeight - 10; // Немного выше TextBox cook
                NameLabel.Location = new System.Drawing.Point(labelX, labelY);


                // Создаем и настраиваем Label для ingredients
                Label IngredientsLabel = new Label();
                IngredientsLabel.Text = "Ингредиенты";
                IngredientsLabel.AutoSize = true; // Чтобы метка автоматически подстраивалась под текст
                IngredientsLabel.Font = new Font(IngredientsLabel.Font.FontFamily, 14, FontStyle.Bold);
                IngredientsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                // Рассчитываем позицию Label над TextBox ingredients по центру
                int ingredientsLabelX = ingredients.Location.X + (ingredients.Width - IngredientsLabel.PreferredWidth) / 2;
                int ingredientsLabelY = ingredients.Location.Y - IngredientsLabel.PreferredHeight - 10; // Немного выше TextBox ingredients
                IngredientsLabel.Location = new System.Drawing.Point(ingredientsLabelX, ingredientsLabelY);


                // Добавляем новую вкладку в TabControl
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage; // Переключаемся на новую вкладку
                tabPage.Controls.Add(IngredientsLabel);
                tabPage.Controls.Add(NameLabel);
                tabPage.Controls.Add(recipeName);
                tabPage.Controls.Add(ingredients);
                tabPage.Controls.Add(cook);
            }   
            else
            {
                MessageBox.Show("Выберите рецепт для открытия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // Пример добавления рецепта
            string newRecipe = "Новый рецепт " + (listBoxRecipes.Items.Count + 1);
            listBoxRecipes.Items.Add(newRecipe);
            DuplicateListBoxItems();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Удаление выделенного рецепта
            if (listBoxRecipes.SelectedItem != null)
            {
                listBoxRecipes.Items.Remove(listBoxRecipes.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите рецепт для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void listBoxRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void DuplicateListBoxItems()
        {
            listBoxDouble.Items.Clear();
            foreach (var item in listBoxRecipes.Items)
            {
                listBoxDouble.Items.Add(item);
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxDouble.SelectedItems)
            {
                listBoxChoosen.Items.Add(item);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            while (listBoxChoosen.SelectedItems.Count > 0)
            {
                listBoxChoosen.Items.Remove(listBoxChoosen.SelectedItems[0]);
            }
        }
    }
        
}
