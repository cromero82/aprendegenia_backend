using CoreLayer.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer
{
    public interface IService<T>
    {
        JResult GetBy(int Id);
        JResult GetAllBy(T model, string field);
        JResult Add(T model);
        JResult Delete(int id);
        JResult Update(T model);
    }
}
