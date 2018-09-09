using ClssVmMdl.Events;
using ClssVmMdl.Events.BarStatus;

namespace ClssVmMdl.Validacion
{
    public class MsgEvents
    {

        public MsgEvents()
        {
            ExEvent = new ExecEventBarSt(ApplicationService.Instance.EventAggregator);

        }
        private ExecEventBarSt ExEvent;

        public void MsgNormal() => ExEvent.MessagShow(0, "", "");

        public void MsgAlmacenar(string Mod, string Estad)
        {

            #region Valor Default 

            if (Estad == "-1")
            {
                ExEvent.MessagShow(2, "Almacenamiento", "Error De sistema");
                return;
            }

            if (Estad == "1")
            {
                ExEvent.MessagShow(1, "", "");
                return;
            }

            if (Estad == "0")
            {
                ExEvent.MessagShow(3, "", "");
                return;
            }

            if (Estad == "2")
            {
                ExEvent.MessagShow(2, "Almacenamiento", "Se debe ingresar todos los campos");
                return;
            }

            int Est = System.Convert.ToInt16(Estad.ToString().Split(';').GetValue(0));

            #endregion

            switch (Mod)
            {
                case "mtdp":

                    switch (Est)
                    {
                        default:
                            ExEvent.MessagShow(2, "Almacenamiento", "Registro duplicado, seleccionar nuevo registro");
                            break;
                    }
                    break;

                case "mdpp":

                    switch (Est)
                    {
                        case 3:

                            ExEvent.MessagShow(2, "Almacenamiento", "Registro duplicado, seleccionar nuevo registro");
                            break;

                        case 5:

                            ExEvent.MessagShow(2, "Almacenamiento", "Se encuentra nombre de modelo ya activo");
                            break;

                        case 6:

                            ExEvent.MessagShow(2, "Almacenamiento", "Error en seleccion de edificio");
                            break;
                    }
                    break;

                case "tpsv":
                    switch(Est)
                    {
                        case 3:

                            ExEvent.MessagShow(2, "Almacenamiento", "Seleccionar tipo de reserva");
                            break;

                        case 5:

                            ExEvent.MessagShow(2, "Almacenamiento", "Se encuentra nombre de modelo ya activo");
                            break;

                        case 6:

                            ExEvent.MessagShow(2, "Almacenamiento", "Error en seleccion de edificio");
                            break;

                    }
                    break;

            }

        }

    }
}
