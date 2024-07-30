import React, { Fragment, useState } from 'react';//hooks
import axios from "axios";//usado para fazer as requisições

function Registration(){

  //definindo os estados para name, phoneNo e address
  const [name, setName] = useState('');
  const [phoneNo, setPhoneNo] = useState('');
  const [address, setAddress] = useState('');


  //função para atualizar o estado do name, phoneno e address
  const handleNameChange = (value) => {
    setName(value);
  };
  const handlePhoneNOChange = (value) => {
    setPhoneNo(value);
  };
  const handleAddressChange = (value) => {
    setAddress(value);
  };


  //função para salvar os dados, ela é chamada quando clickado o botão
  const handleSave = () => {
    //criando o objeto(data) com os atributos e seus valores sendo os estados
    //IsActive sempre vem como "1"
    const data = {
        Name : name,
        PhoneNo : phoneNo,
        Address : address,
        IsActive : 1
    };

    //Definindo o caminho da URL para a requisição POST
    const url = 'https://localhost:44304/api/Test/Registration';

    //fazendo a requisição POST usando o axios
    //sinaliza o caminho que deve ocorrer essa requisição "url"
    //envia informações no corpo dessa requisição "data"
    axios.post(url,data).then((result) => {//then é quando a requisição da certo e o result é a resposta da requisição
        //se o dado dessa resposta for isso
        if(result.data == 'Data inserted.')
            alert('data saved');
        else
        {
            alert(result.data);
        }
    }).catch((error) => {//catch é porque deu ruim a requisição e o error é a resposta de erro que ela retorna
     alert(error);   
    })
  };

    return(
        <Fragment>
        <div>Registration</div>
        {/*Campo de input para o nome*/}
        <label>Name</label>
        <input 
          type="text" 
          id="txtName" 
          placeholder="Enter Name"
          /*onChange, um evento que ocorre sempre que algo no input ou select é alterado
            no caso cada mudança é um 'e' e toda vez que ele se altera eu pego seu valor e envio para a função criada */ 
          onChange={(e) => handleNameChange(e.target.value)} 
        /><br></br>
        {/*Campo de input para o phoneno*/}
        <label>Phone No</label>
        <input type="text" id="txtPhoneNo" placeholder="Enter Phone No" onChange={(e) => handlePhoneNOChange(e.target.value)}  /><br></br>
        {/*Campo de input para o address*/}
        <label>Address</label>
        <input type="text" id="txtAddress" placeholder="Enter Address" onChange={(e) => handleAddressChange(e.target.value)} /><br></br>
        {/*Botão que aciona a função de salvamento de dados*/}
        <button 
           /*onClick, é um evento que ocorre toda vez que o botão é clicado, nesse caso eu aciono a função criada
             toda vez que esse botão é clickado */
           onClick={() => handleSave()}
        >Save</button>
        </Fragment>
    )
}


export default Registration;