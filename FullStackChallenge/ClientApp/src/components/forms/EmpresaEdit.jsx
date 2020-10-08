import React, { useState } from "react";
import {
  Button,
  FormGroup,
  FormControl,
  FormLabel,
  Form,
} from "react-bootstrap";
import axios from "axios";

const URL = "https://localhost:44399/api/v1/empresa";

export default (props) => {
  const [nomeFantasia, setNomeFantasia] = useState(
    props.location.item.nomeFantasia
  );
  const [uf, setUf] = useState(props.location.item.uf);
  const [cnpj, setCnpj] = useState(props.location.item.cnpj);
  const [fornecedores, setFornecedores] = useState(
    props.location.item.fornecedores
  );
  const [erros, setErros] = useState({ Cnpj: [], Nome: [] });

  function handleSubmit(e) {
    e.preventDefault();

    axios
      .put(`${URL}`, {
        id: props.location.item.id,
        nomeFantasia,
        uf,
        cnpj: +cnpj,
        fornecedores,
      })
      .then((resp) => console.log(resp.data))
      .catch((resp) => {
        setErros(resp.response.data.errors);
      });
  }

  return (
    <div className="Login">
      <form onSubmit={handleSubmit}>
        <FormGroup controlId="nome">
          <FormLabel>Nome</FormLabel>
          <FormControl
            autoFocus
            type="text"
            value={nomeFantasia}
            onChange={(e) => setNomeFantasia(e.target.value)}
          />
        </FormGroup>
        <FormGroup controlId="cnpj">
          <FormLabel>CNPJ</FormLabel>
          <FormControl
            value={cnpj}
            onChange={(e) => setCnpj(e.target.value)}
            type="number"
          />
        </FormGroup>
        <FormGroup controlId="estado">
          <FormLabel>Estado</FormLabel>
          <FormControl as="select" onChange={(e) => setUf(e.target.value)}>
            <option defaultValue>Escolha...</option>
            <option value="AC">Acre</option>
            <option value="AL">Alagoas</option>
            <option value="AP">Amapá</option>
            <option value="AM">Amazonas</option>
            <option value="BA">Bahia</option>
            <option value="CE">Ceará</option>
            <option value="DF">Distrito Federal</option>
            <option value="ES">Espírito Santo</option>
            <option value="GO">Goiás</option>
            <option value="MA">Maranhão</option>
            <option value="MT">Mato Grosso</option>
            <option value="MS">Mato Grosso do Sul</option>
            <option value="MG">Minas Gerais</option>
            <option value="PA">Pará</option>
            <option value="PB">Paraíba</option>
            <option value="PR">Paraná</option>
            <option value="PE">Pernambuco</option>
            <option value="PI">Piauí</option>
            <option value="RJ">Rio de Janeiro</option>
            <option value="RN">Rio Grande do Norte</option>
            <option value="RS">Rio Grande do Sul</option>
            <option value="RO">Rondônia</option>
            <option value="RR">Roraima</option>
            <option value="SC">Santa Catarina</option>
            <option value="SP">São Paulo</option>
            <option value="SE">Sergipe</option>
            <option value="TO">Tocantins</option>
          </FormControl>
        </FormGroup>
        <Button className="btn btn-primary" type="submit">
          Atualizar
        </Button>
      </form>
    </div>
  );
};
