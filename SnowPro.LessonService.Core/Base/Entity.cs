using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowPro.LessonService.Core.Base
{
    public abstract class Entity<T>(T id)
    {
        public T GetId()
        {
            return id;
        }
    }
}
