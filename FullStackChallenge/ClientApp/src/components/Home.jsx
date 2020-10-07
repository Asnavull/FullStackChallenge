import React from "react";
import connect from "redux";

export default (props) => {
  function getLinhas() {
    return produtos.map((produto, i) => {
      return (
        <tr key={produto.id} className={i % 2 === 0 ? "Par" : "Impar"}></tr>
      );
    });
  }
};

export default connect()(Home);
