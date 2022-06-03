using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class FitnessContext: DbContext
    {
        public FitnessContext(): base()
        {
        }
    }
}
