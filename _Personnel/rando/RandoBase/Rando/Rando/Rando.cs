using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Globalization;
using NetTopologySuite;
using NetTopologySuite.IO;
//using NetTopologySuite.IO.GPX;

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

            
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {


            Pen myPen = new Pen(Color.Red);
            myPen.Width = 500;

            var pointsRunning = LireGpx(@"gpx\Running.gpx").ToList();

            // const int edgePadding = 20;

            double lengthRun = pointsRunning.Aggregate((a, b) => Math.Sqrt(Math.Pow(Math.Sqrt(Math.Pow(a.lat - b.lat, 2) + Math.Pow(a.lon - b.lon, 2)), 2) + Math.Pow(a.ele - b.ele, 2));
 );

            MessageBox.Show(Convert.ToString(lengthRun));

            ExercicesLinq();


            // this.CreateGraphics().DrawLines(myPen, (Point[])pointsRunning);
        }

        private void ExercicesLinq()
        {


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
                                     double ele = double.Parse(tp.Attribute("ele").Value, CultureInfo.InvariantCulture);


                                     int x = (int)(lon /**10000*/);
                                     int y = (int)(lat /** -10000*/);

                                     return new Point(x, y);
                                 });

            return trackpoints;
        }
    }
}
