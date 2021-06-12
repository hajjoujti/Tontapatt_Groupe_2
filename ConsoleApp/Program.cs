using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TerrainBU bu = new();
            //Terrain t = bu.GetTerrain(264);

            //Console.WriteLine("Nom terrain : " + t.NomTerrain + "\nAdresse : " + t.AdresseTerrain + "\nSurface : "
            //    + t.SurfaceTerrain + "\nDescription : " + t.DescriptionTerrain + "\nDate enregistrement : " + t.DateEnregistrementTerrain.ToString("dd/MM/yyyy"));

            TerrainDetails td = bu.GetByIdWithDetails(1);
            Console.WriteLine("Nom terrain : " + td.NomTerrain + "\nAdresse : " + td.AdresseTerrain + "\nSurface : "
                + td.SurfaceTerrain + "\nDescription : " + td.DescriptionTerrain + "\nDate enregistrement : " + td.DateEnregistrementTerrain.ToString("dd/MM/yyyy")
                + "\nNom proprieteaire : " + td.NomUtilisateur + "\nPrenom proprietaire : " + td.PrenomUtilisateur + "\nDescription proprietaire : " + td.DescriptionTerrain
                + "\nNom ville : " + td.NomVilleTerrain + "\nCode postal : " + td.CodePostalTerrain + "\nLongitude : " + td.LongitudeTerrain + "\nLatitude : " + td.LatitudeTerrain + "\nHumidite : " + td.HumiditeTerrain + "\nComposition : " + td.CompositionTerrain + "\nPente : " + td.PenteTerrain + "\nHauteur Herbe : " + td.HauteurHerbe);
            foreach(CompositionVegetationDetails cds in td.CompositionsVegetationTerrain)
            {
                Console.WriteLine("Type vegetation : " + cds.TypeVegetaion + " --> Pourcentage : " + cds.PourcentageVegetation);
            }

            //string mail = "Merci.McNully@gmail.com";
            //string mdp = "attilio";
            //UtilisateurBU bu = new();
            //Utilisateur u = bu.GetUtilisateurAuthentification(mail,mdp);
            //Console.WriteLine("Nom : " + u.NomUtilisateur + "\nPrenom : " + u.PrenomUtilisateur);
        }
    }
}
