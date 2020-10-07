import React from "react";

export default (props) => {
  function preencherTabela() {
    return props.listEmpresa.map((item, i) => {
      return (
        <tr key={i}>
          <td>{item.cnpj}</td>
          <td>{item.nomeFantasia}</td>
          <td>{item.uf}</td>
        </tr>
      );
    });
  }

  return (
    <div>
      <div className="input-group mb-3">
        <div className="input-group-prepend">
          <span className="input-group-text" id="">
            Empresas
          </span>
        </div>

        <input
          type="text"
          className="form-control"
          id="nomeEmpresa"
          placeholder="Nome Empresa"
          value={props.description}
          onChange={props.handleChange}
        />

        <div className="input-group-append">
          <div class="form-check form-check-inline">
            <input
              class="form-check-input"
              type="radio"
              name="searchOptions"
              id="cnpjRadio"
              value="documento"
            />
            <label class="form-check-label" for="inlineRadio1">
              CNPJ
            </label>
            <input
              class="form-check-input"
              type="radio"
              name="searchOptions"
              id="nomeRadio"
              value="nome"
            />
            <label class="form-check-label" for="inlineRadio1">
              NOME
            </label>
          </div>
          <button
            className="btn btn-outline-secondary"
            type="button"
            id="inputGroupFileAddon04"
            onClick={props.handleAdd}
          >
            Procurar
          </button>
        </div>
      </div>
      <div className="table-responsive">
        <table className="table">
          <thead>
            <tr>
              <th scope="col">CNPJ</th>
              <th scope="col">NOME</th>
              <th scope="col">UF</th>
            </tr>
          </thead>
          <tbody>{preencherTabela()}</tbody>
        </table>
      </div>
    </div>
  );
};
