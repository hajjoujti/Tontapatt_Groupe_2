﻿using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class RaisonAnnulationDemandeBU
    {
        public List<RaisonAnnulationDemande> GetAll()
        {
            return new RaisonAnnulationDemandeDAO().GetAll();
        }
    }
}
