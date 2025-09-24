using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Globalization;

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

            ExercicesLinq();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            Point[] points = new Point[8]
            {
                new Point(30,50),
                new Point(50,10),
                new Point(80,50),
                new Point(111,400),
                new Point(120,50),
                new Point(150,10),
                new Point(180,50),
                new Point(230,400)

            };

            this.CreateGraphics().DrawLines(myPen, points);
        }

        private void ExercicesLinq()
        {
            Array pointsRunning = LireGpx(@"gpx\Running.gpx").ToArray();
            int LengthPoints = pointsRunning.Length;
            MessageBox.Show(Convert.ToString(LengthPoints));
        }

        private IEnumerable<Point> LireGpx(string relativePath)
        {
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            var doc = XDocument.Load(fullPath);

            XNamespace ns = "http://www.topografix.com/GPX/1/1";

            var trackpoints = doc.Descendants(ns + "trkpt")
                                 .Select(tp =>
                                 {
                                     double lat = double.Parse(tp.Attribute("lat").Value, CultureInfo.InvariantCulture); //CultureInfo.InvariantCulture car si non format non valide
                                     double lon = double.Parse(tp.Attribute("lon").Value, CultureInfo.InvariantCulture);

                                     int x = (int)(lon /** 10000*/);
                                     int y = (int)(lat /** -10000*/);

                                     return new Point(x, y);
                                 });

            return trackpoints;
        }
    }
}
