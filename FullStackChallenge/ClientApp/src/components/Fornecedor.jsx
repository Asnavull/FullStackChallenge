import React, { Component } from "react";
import axios from "axios";
import ListaEmpresa from "./ListaEmpresa";
// import { connect } from "react-redux";

const URL = "https://localhost:44399/api/v1/empresa";

export default class Fornecedor extends Component {
  constructor(props) {
    super(props);
    this.state = { description: "", listEmpresa: [] };

    this.handleAdd = this.handleAdd.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(e) {
    this.setState({ ...this.state, description: e.target.value });
  }

  handleAdd() {
    var tipoPesquisa = document.getElementById("nomeRadio");
    
    if (tipoPesquisa.checked) {
      axios.get(`${URL}/find?nome=${this.state.description}`).then((resp) => {
        this.setState({ ...this.state, listEmpresa: resp.data });
      });
    } else {
      axios
        .get(`${URL}/find?documento=${this.state.description}`)
        .then((resp) => {
          this.setState({ ...this.state, listEmpresa: resp.data });
        });
    }
  }

  render() {
    return (
      <form>
        <div className="form-row">
          <div className="form-group col-md-6">
            <label htmlFor="nomeFornecedor">Nome</label>
            <input type="text" className="form-control" id="nomeFornecedor" />
          </div>
          <div className="form-group col-md-6">
            <label htmlFor="emailFornecedor">Email</label>
            <input type="email" className="form-control" id="emailFornecedor" />
          </div>
        </div>
        <div className="form-row">
          <div className="form-group col-md-6">
            <label htmlFor="cpfCnpj">CPF / CNPJ</label>
            <input
              type="number"
              maxLength="14"
              className="form-control"
              id="cpfCnpj"
            />
          </div>
          <div className="form-group col-md-6">
            <label htmlFor="rg">RG</label>
            <input type="text" className="form-control" id="rg" />
          </div>
        </div>

        <ListaEmpresa
          handleAdd={this.handleAdd}
          description={this.state.description}
          handleChange={this.handleChange}
          listEmpresa={this.state.listEmpresa}
        />

        <div className="form-row">
          <div className="form-group col-md-4">
            <label htmlFor="inputState">State</label>
            <select id="inputState" className="form-control">
              <option defaultValue>Choose...</option>
              <option>...</option>
            </select>
          </div>
        </div>

        <button type="submit" className="btn btn-primary">
          Adicionar
        </button>
      </form>
    );
  }
}

//export default connect()(Fornecedor);
