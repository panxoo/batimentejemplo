using ClssVmMdl.Calling;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClssVmMdl.VarStatic
{
    public static class ParSistem
    {
        public static string NomSelDepart;
        public static int IdCond;
        public static int IdCondEdf;
        public static bool MultiEdef;
        public static string TipSelDepart;
        public static int IdSelDepart;
        public static List<string> LogPanel;
        public static string UsrSes;


        public static void Carga(bool ini)
        {
            CallDatoSistem CallDt = new CallDatoSistem("prst");

            ArrayList Dc;

            Dc = CallDt.SIST_ParamCond();

            MultiEdef = Convert.ToBoolean(Dc[0]);
            IdCond = Convert.ToInt16(Dc[1]);
            IdCondEdf = Convert.ToInt16(Dc[2]);

            if (ini == true)
                LogPanel = new List<string>();
        }

        public static void SelDep(int tp, string Nom, int id)
        {
            switch (tp)
            {
                case 1:
                    TipSelDepart = "Condominio";
                    break;
                case 0:
                    TipSelDepart = "Departamento";
                    break;
            }

            NomSelDepart = Nom;
            IdSelDepart = id;

        }

        public static void InsPanelLog(string st)
        {
            if (LogPanel.Count > 9)
            {
                LogPanel.RemoveAt(0);
                LogPanel.Add(st);
            }
            else
                LogPanel.Add(st);
        }


    }
}
