import React from "react";
import { NavLink } from "reactstrap";
import { Link } from "react-router-dom";

export default (props) => {
  function preencherTabela() {
    const list = props.listFornecedor || [];

    return list.map((item) => (
      <tr key={item.id}>
        <td>{item.cpfCnpj}</td>
        <td>{item.nome}</td>
        <td>{item.email}</td>
        <td>{item.rg}</td>
        <td>{item.dataNascimento}</td>
        <td>
          <div className="btn-group" role="group">
            <NavLink
              tag={Link}
              to={{
                pathname: "/fornecedor/edit",
                item,
              }}
              type="button"
              className="btn btn-warning btn-sm"
            >
              EDIT
            </NavLink>
            <button
              type="button"
              className="btn btn-danger btn-sm"
              onClick={() => props.handleDelete(item)}
            >
              DELETE
            </button>
          </div>
        </td>
      </tr>
    ));
  }

  return (
    <div>
      <div className="input-group mb-3">
        <div className="input-group-prepend">
          <span className="input-group-text">Fornecedores</span>
        </div>

        <input
          type="text"
          className="form-control"
          id="campoPesquisa"
          placeholder="Nome Fornecedor ou documento ou email"
          name="campoPesquisa"
          value={props.campoPesquisa}
          onChange={props.handleChange}
        />

        <div className="input-group-append">
          <div className="form-check form-check-inline input-group-text">
            <input
              className="form-check-input ml-2"
              type="radio"
              name="searchOptions"
              id="cnpjRadio"
              value="documento"
            />
            <label className="form-check-label" htmlFor="cnpjRadio">
              CNPJ
            </label>
            <input
              className="form-check-input ml-2"
              type="radio"
              name="searchOptions"
              id="nomeRadio"
              value="nome"
            />
            <label className="form-check-label" htmlFor="nomeRadio">
              NOME
            </label>
            <input
              className="form-check-input"
              type="radio"
              name="searchOptions"
              id="emailRadio"
              value="nome"
            />
            <label className="form-check-label" htmlFor="emailRadio">
              EMAIL
            </label>
          </div>
          <button
            className="btn btn-outline-secondary"
            type="button"
            id="inputGroupFileAddon04"
            onClick={props.handleSearch}
          >
            Procurar
          </button>
        </div>
      </div>
      <div className="table-responsive">
        <table className="table overflow-auto">
          <thead>
            <tr>
              <th scope="col">CPF/CNPJ</th>
              <th scope="col">NOME</th>
              <th scope="col">EMAIL</th>
              <th scope="col">RG</th>
              <th scope="col">DATA NASCIMENTO</th>
              <th scope="col">ACTIONS</th>
            </tr>
          </thead>
          <tbody>{preencherTabela()}</tbody>
        </table>
      </div>
    </div>
  );
};
