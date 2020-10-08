import React, { useState } from "react";
import { Button, FormGroup, FormControl, FormLabel } from "react-bootstrap";
import axios from "axios";

const URL = "https://localhost:44369/api/v1/fornecedor";

export default (props) => {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [cpfCnpj, setCpfCnpj] = useState("");
  const [rg, setRg] = useState(null);
  const [dataNascimento, setDataNascimento] = useState(null);
  const [empresas, setEmpresas] = useState(new Array());

  function handleSubmit(e) {
    e.preventDefault();

    axios
      .post(URL, {
        nome,
        email,
        cpfCnpj: +cpfCnpj,
        rg,
        dataNascimento,
        empresas,
      })
      .then((resp) => console.log(resp))
      .catch((resp) => console.log(resp.data));
  }

  return (
    <div className="Login">
      <form onSubmit={handleSubmit}>
        <FormGroup controlId="nome">
          <FormLabel>Nome</FormLabel>
          <FormControl
            autoFocus
            type="text"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
          />
        </FormGroup>

        <FormGroup controlId="email">
          <FormLabel>Email</FormLabel>
          <FormControl
            autoFocus
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </FormGroup>

        <FormGroup controlId="cpfCnpj">
          <FormLabel>CPF/CNPJ</FormLabel>
          <FormControl
            value={cpfCnpj}
            onChange={(e) => setCpfCnpj(e.target.value)}
            type="number"
          />
        </FormGroup>

        <FormGroup controlId="rg">
          <FormLabel>RG</FormLabel>
          <FormControl
            value={rg}
            onChange={(e) => setRg(e.target.value)}
            type="text"
          />
        </FormGroup>

        <FormGroup controlId="dataNascimento">
          <FormLabel>DATA DE NASCIMENTO</FormLabel>
          <FormControl
            value={dataNascimento}
            onChange={(e) => setDataNascimento(e.target.value)}
            type="date"
          />
        </FormGroup>

        <Button className="btn btn-primary" type="submit">
          Adicionar
        </Button>
      </form>
    </div>
  );
};
