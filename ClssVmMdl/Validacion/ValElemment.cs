using System.Collections.Generic;
using ClssVmMdl.Events.BarStatus;
using ClssVmMdl.Events;

namespace ClssVmMdl.Validacion
{
    class ValElemment
    {
        private ExecEventBarSt ExEvent;

        public ValElemment()
        {
            ExEvent = new ExecEventBarSt(ApplicationService.Instance.EventAggregator);
        }

        public bool EmptyStrg(List<string> val)
        {
            foreach (string st in val)
            {
                if (string.IsNullOrEmpty(st) || string.IsNullOrWhiteSpace(st))
                {
                    ExEvent.MessagShow(2, "no se ha registrado datos", "Se debe llenar todos los campos");

                    return false;
                }
            }
            return true;
        }

        public bool NumMayCero(List<int> val)
        {
            foreach(int it in val)
            {
                if(!(it > 0))
                {
                    ExEvent.MessagShow(2, "no se ha registrado datos", "El campo debe ser mayor a 0");
                    return false;
                }
            }
            return true;
        }

        public bool NumMayCero(List<double> val)
        {
            foreach (int it in val)
            {
                if (!(it > 0))
                {
                    ExEvent.MessagShow(2, "no se ha registrado datos", "El campo debe ser mayor a 0");
                    return false;
                }
            }
            return true;
        }

        public bool NumCeroMay(List<int> val)
        {
            foreach (int it in val)
            {
                if (!(it == 0 || it > 0))
                {
                    ExEvent.MessagShow(2, "no se ha registrado datos", "El campo no puede ser negativo");
                    return false;
                }
            }
            return true;
        }

        public bool NumCeroMay(List<float> val)
        {
            foreach (int it in val)
            {
                if (!(it == 0 || it > 0))
                {
                    ExEvent.MessagShow(2, "no se ha registrado datos", "El campo no puede ser negativo");
                    return false;
                }
            }
            return true;
        }
    }
}


