using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Utilities.DTOs.ResultViewModel
{
    public class ResultViewModel : ResultViewModel<object> { }

    public class ResultViewModel<T> where T : class
    {
        public ResultViewModel()
        {
            ResultView = ResultViewEnum.Error;
        }
        public virtual string Message { get; set; }

        public virtual ResultViewEnum ResultView { get; set; }

        public virtual bool IsSuccess => ResultView == ResultViewEnum.Success;

        public virtual T Data { get; set; }
    }

    public enum ResultViewEnum
    {
        Error = 0,
        Success = 1
    }
}
