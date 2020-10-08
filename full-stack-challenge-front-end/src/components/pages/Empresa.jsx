import React, { Component, useState } from "react";
import axios from "axios";
import { NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import TableEmpresa from "../tables/TableEmpresa";

const URL = "https://localhost:44369/api/v1/empresa";

export default class Empresa extends Component {
  constructor(props) {
    super(props);
    this.state = {
      campoPesquisa: "",
      listEmpresa: [],
    };

    this.handleAdd = this.handleSearch.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.handleDelete = this.handleDelete.bind(this);
    this.listAll = this.listAll.bind(this);

    this.listAll();
  }

  handleDelete(item) {
    axios.delete(`${URL}/${item.id}`).then(() => this.listAll());
  }

  handleChange(e) {
    this.setState({ ...this.state, [e.target.name]: e.target.value });
  }

  listAll() {
    axios.get(URL).then((resp) => {
      this.setState({ ...this.state, listEmpresa: resp.data });
    });
  }

  handleSearch() {
    var tipoPesquisa = document.getElementById("nomeRadio");

    if (this.state.campoPesquisa === "") this.listAll();
    else {
      if (tipoPesquisa.checked) {
        axios
          .get(`${URL}/find?nome=${this.state.campoPesquisa}`)
          .then((resp) => {
            this.setState({ ...this.state, listEmpresa: resp.data });
          });
      } else {
        axios
          .get(`${URL}/find?documento=${this.state.campoPesquisa}`)
          .then((resp) => {
            this.setState({ ...this.state, listEmpresa: resp.data });
          });
      }
    }
  }

  render() {
    return (
      <div>
        <TableEmpresa
          campoPesquisa={this.state.campoPesquisa}
          listEmpresa={this.state.listEmpresa}
          handleSearch={this.handleSearch}
          handleChange={this.handleChange}
          handleDelete={this.handleDelete}
        />

        <NavLink
          tag={Link}
          to={{
            pathname: "/empresa/cadastro",
          }}
          type="button"
          className="btn btn-primary btn-lg btn-block"
        >
          Cadastrar Empresa
        </NavLink>
      </div>
    );
  }
}
