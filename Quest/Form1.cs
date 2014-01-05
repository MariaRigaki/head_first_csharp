using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quest
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            game = new Game(new Rectangle(106, 80, 580, 234));
            game.NewLevel(random);
            UpdateCharacters();

            base.OnLoad(e);
        }

        private void UpdateCharacters()
        {
            player.Location = game.PlayerLocation;
            playerHitPoints.Text = game.PlayerHitPoints.ToString();
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;
            player.Visible = true;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batBox.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghostBox.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoulBox.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
                if (!showBat)
                {
                    batBox.Visible = false;
                    batHitPoints.Text = "";
                }
                else batBox.Visible = true;
                
                if (!showGhost)
                {
                    ghostBox.Visible = false;
                    ghostHitPoints.Text = "";
                }
                else ghostBox.Visible = true;
                
                if (!showGhoul)
                {
                    ghoulBox.Visible = false;
                    ghoulHitPoints.Text = "";
                }
                else ghoulBox.Visible = true;

                swordInv.Visible = false;
                bowInv.Visible = false;
                redPotionInv.Visible = false;
                bluePotionInv.Visible = false;
                maceInv.Visible = false;
                Control weaponControl = null;

                switch (game.WeaponInRoom.Name)
                {
                    case "Sword":
                        weaponControl = sword;
                        break;
                    case "Bow":
                        weaponControl = bow;
                        break;
                    case "Mace":
                        weaponControl = mace;
                        break;
                    case "Blue Potion":
                        weaponControl = bluePotion;
                        break;
                    case "Red Potion":
                        weaponControl = bluePotion;
                        break;
                }
                weaponControl.Visible = true;
                if (game.CheckPlayerInventory("Sword")) swordInv.Visible = true;
                if (game.CheckPlayerInventory("Bow")) bowInv.Visible = true;
                if (game.CheckPlayerInventory("Mace")) maceInv.Visible = true;
                if (game.CheckPlayerInventory("Blue Potion")) bluePotionInv.Visible = true;
                if (game.CheckPlayerInventory("Red Potion")) redPotionInv.Visible = true;

                weaponControl.Location = game.WeaponInRoom.Location;
                if (game.WeaponInRoom.PickedUp)
                    weaponControl.Visible = false;
                else
                    weaponControl.Visible = true;

                if (game.PlayerHitPoints <= 0)
                {
                    MessageBox.Show("You died");
                    Application.Exit();
                }
                if (enemiesShown < 1)
                {
                    MessageBox.Show("You have defeated the enemies on this level");
                    game.NewLevel(random);
                    UpdateCharacters();
                }
            }
        }

        


        private void buttonUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void buttonAttackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void buttonAttackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void buttonAttackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void buttonAttacRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void swordInv_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                ClearEquiped();
                swordInv.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void bowInv_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                ClearEquiped();
                bowInv.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void bluePotionInv_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                game.Equip("Blue Potion");
                ClearEquiped();
                bluePotionInv.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void redPotionInv_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red Potion"))
            {
                game.Equip("Red Potion");
                ClearEquiped();
                redPotionInv.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void maceInv_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                ClearEquiped();
                maceInv.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void ClearEquiped()
        {
            swordInv.BorderStyle = BorderStyle.None;
            bowInv.BorderStyle = BorderStyle.None;
            redPotionInv.BorderStyle = BorderStyle.None;
            bluePotionInv.BorderStyle = BorderStyle.None;
            maceInv.BorderStyle = BorderStyle.None;
        }
    }
}
