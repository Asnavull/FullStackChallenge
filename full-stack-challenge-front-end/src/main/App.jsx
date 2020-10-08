import "bootstrap/dist/css/bootstrap.css";
import React from "react";

import Empresa from "../components/pages/Empresa";
import Layout from "../components/template/Layout";
import { Route, Redirect } from "react-router";
import Fornecedor from "../components/pages/Fornecedor";
import EmpresaForm from "../components/forms/EmpresaForm";
import FornecedorForm from "../components/forms/FornecedorForm";
import EmpresaEdit from "../components/forms/EmpresaEdit";
import FornecedorEdit from "../components/forms/FornecedorEdit";

export default (props) => {
  return (
    <Layout>
      <Route exact path="/" />
      <Route path="/empresa" component={Empresa} />
      <Route path="/fornecedor" component={Fornecedor} />
      <Route path="/empresa/cadastro" component={EmpresaForm} />
      <Route path="/fornecedor/cadastro" component={FornecedorForm} />
      <Route path="/empresa/edit" component={EmpresaEdit} />
      <Route path="/fornecedor/edit" component={FornecedorEdit} />
      <Redirect from="*" to="/" />
    </Layout>
  );
};
