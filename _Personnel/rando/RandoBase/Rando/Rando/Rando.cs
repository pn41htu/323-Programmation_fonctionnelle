using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
1.Lire le `.gpx` pour obtenir une liste de trackpoints
2. Transformer la liste pour obtenir une liste de points graphiques (`System.Drawing.Point`)
3. Dessiner la trace graphiquement en une couleur
4. Utiliser la fonction `Aggregate` pour calculer la longueur du parcours
5. Utiliser les fonctions `Zip` et `Skip` pour calculer la même longueur d'une manière différente
6. Utilisez une transformation pour dessiner le parcours avec une couleur qui est fonction de l'altitude. Attention: vous devez faire cela avec LinQ, sans boucle `for` ou `foreach`
7. Dessiner le profil de la course
8. Calculer le dénivelé positif et négatif
*/

namespace Rando
{
    public partial class Rando : Form
    {
        public Rando()
        {
            InitializeComponent();

            // Exercices LINQ sur les points
            ExercicesLinq();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            Point[] points = new Point[4]
            {
                new Point(30,50),
                new Point(50,10),
                new Point(80,50),
                new Point(111,400)
            };

            this.CreateGraphics().DrawLines(myPen, points);
        }

        private void ExercicesLinq()
        {
            Point[] points = new Point[14]
            {
    new Point(30,50),
    new Point(50,10),
    new Point(80,50),
    new Point(111,400),
    new Point(140,380),
    new Point(160,360),
    new Point(180,300),
    new Point(200,250),
    new Point(230,200),
    new Point(260,220),
    new Point(300,260),
    new Point(340,300),
    new Point(380,350),
    new Point(420,400)
            };
            
            string output = "";                                                          
            // 1/2 (tracé moins précis)                                                  
            var reduits = points.Where((p, i) => i % 2 == 0).ToList();                   
            output += "1/2 points : "                                                    
                   + string.Join(" | ", reduits.Select(p => $"({p.X},{p.Y})")) + "\n";   
                                                                                         
            // distance totale                                                        
            double longueur = points.Zip(points.Skip(1),                                 
                (a, b) => Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)))    
                .Sum();                                                                  
            output += $"distance totale = {longueur:F2}\n";

            // denivele
            int positif = points
                .Skip(1)
                .Select((p, i) => p.Y - points[i].Y)
                .Where(d => d > 0)
                .Sum();

            int negatif = points
                .Skip(1)
                .Select((p, i) => p.Y - points[i].Y)
                .Where(d => d < 0)
                .Sum();

            output += $"Dénivelé positif = {positif} et négatif = {negatif}\n";

            // Max et min                          
            int maxY = points.Max(p => p.Y);                                             
            int minY = points.Min(p => p.Y);
            output += $"(Y max) = {maxY}, (Y min) = {minY}\n";
                                                                                         
            // moyenne                                                
            double moyX = points.Average(p => p.X);
            double moyY = points.Average(p => p.Y);
            output += $"Moyene = ({moyX:F1}, {moyY:F1})\n";                        

            MessageBox.Show(output, "Logs output");
        }
    }
}
