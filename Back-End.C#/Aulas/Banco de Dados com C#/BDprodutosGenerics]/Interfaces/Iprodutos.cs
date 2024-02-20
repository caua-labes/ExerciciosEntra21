﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDprodutosGenerics_.Interfaces
{
    public interface Iprodutos<T>
    {
        public bool add(T t);
        public void Consultar(T t);
        public bool Alterar(T t);
        public void Excluir(T t);
        public void ConsultarID(T t);

        
    }
}
