import React, { Component, useState } from "react";
import axios from "axios";
import { NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import TableFornecedor from "../tables/TableFornecedor";

const URL = "https://localhost:44369/api/v1/fornecedor";

export default class Fornecedor extends Component {
  constructor(props) {
    super(props);
    this.state = {
      campoPesquisa: "",
      listFornecedor: [],
    };

    this.handleSearch = this.handleSearch.bind(this);
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
      this.setState({ ...this.state, listFornecedor: resp.data });
    });
  }

  handleSearch() {
    switch (true) {
      case this.state.campoPesquisa === "":
        this.listAll();
        break;

      case document.getElementById("nomeRadio").checked:
        axios
          .get(`${URL}/find?nome=${this.state.campoPesquisa}`)
          .then((resp) => {
            this.setState({ ...this.state, listFornecedor: resp.data });
          });
        break;

      case document.getElementById("cnpjRadio").checked:
        axios
          .get(`${URL}/find?documento=${this.state.campoPesquisa}`)
          .then((resp) => {
            this.setState({ ...this.state, listFornecedor: resp.data });
          });
        break;

      case document.getElementById("emailRadio").checked:
        axios
          .get(`${URL}/find?email=${this.state.campoPesquisa}`)
          .then((resp) => {
            this.setState({ ...this.state, listFornecedor: resp.data });
          });
        break;
      default:
        break;
    }
  }

  render() {
    return (
      <div>
        <TableFornecedor
          campoPesquisa={this.state.campoPesquisa}
          listFornecedor={this.state.listFornecedor}
          handleSearch={this.handleSearch}
          handleChange={this.handleChange}
          handleDelete={this.handleDelete}
        />

        <NavLink
          tag={Link}
          to={{
            pathname: "/fornecedor/cadastro",
          }}
          type="button"
          className="btn btn-primary btn-lg btn-block"
        >
          Cadastrar Fornecedor
        </NavLink>
      </div>
    );
  }
}
