import "bootstrap/dist/css/bootstrap.css";
import React from "react";

import Empresa from "../components/Empresa";
import Layout from "../components/Layout";
import { Route, Redirect } from "react-router";
import Fornecedor from "../components/Fornecedor";

export default (props) => {
  return (
    <Layout>
      <Route exact path="/" />
      <Route path="/empresa" component={Empresa} />
      <Route path="/fornecedor" component={Fornecedor} />
      <Redirect from="*" to="/" />
    </Layout>
  );
};
