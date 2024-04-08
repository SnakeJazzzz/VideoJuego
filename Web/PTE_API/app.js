"use strict";

// Importing modules
import express from "express";

import mysql from "mysql2/promise";

const app = express();
const port = 3000;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Function to connect to the MySQL database

// The async keyword is used to define an asynchronous function. An asynchronous function is a function that operates asynchronously, using an implicit Promise to return its result.
// A Promise is an object representing the eventual completion or failure of an asynchronous operation. It allows you to associate handlers with an asynchronous action's eventual success value or failure reason.

async function connectToDB() {
  return await mysql.createConnection({
    host: "localhost",
    user: "tc2005b",
    password: "tec123",
    database: "PTE",
  });
}


//Endpoint para verificar si los datos del log in estan correctos.
app.get("/api/usuarios/:username/:password", async (request, response) => {
    let connection = null;
  
    try {
    console.log("Username: "+ request.params.username + "\nPassword: "+request.params.password);

    connection = await connectToDB();
  
      // The execute method is used to execute a SQL query. It returns a Promise that resolves with an array containing the results of the query (results) and an array containing the metadata of the results (fields).
      
    const [results, fields] = await connection.execute(
        "SELECT NombreUsuario, Contraseña FROM Usuarios WHERE NombreUsuario LIKE ?;",
        [request.params.username]
    );

        
    if (results[0] == undefined)
    {
        console.log("Username doesnt exist.\n");
        response.status(200).json({"Success": false, "Error": "Username doesnt exist."});
    }
    
    else if (results[0]["NombreUsuario"] === request.params.username && results[0]["Contraseña"] === request.params.password )
    {
    console.log("Access granted.\n");
    response.status(200).json({"Success": true});
  }
    else if (results[0]["NombreUsuario"] === request.params.username)
    {
    console.log("Wrong password.\n");
    response.status(200).json({"Success": false, "Error": "Wrong password."});

    }
    }
    catch (error) {
      response.status(500);
      response.json(error);
      console.log(error);
    }
    finally {
      if (connection !== null) {
        connection.end();
        console.log("Connection closed succesfully!");
      }
    }
  });


  //Endpoint para crear una cuenta
  app.post("/api/usuarios/", async (request, response) => {
    let connection = null;

    try {
    //console.log("Request arrived");
    const username = request.body.username;
    const password = request.body.password;
    //console.log(request.body);
  
    //const returnjson = {};
    connection = await connectToDB();

    const [results, fields] = await connection.execute(
        "SELECT NombreUsuario FROM Usuarios WHERE NombreUsuario LIKE ?;",
        [username]
    );
    
    if (results[0] !== undefined)
    {
        console.log("Couldnt create account: Username already exists.");
        response.status(200).json({"Success": false, "Error": "Username already exists."});
       
    }
    else if ( username.length > 40 || password.length > 40)
    {
        console.log("Couldnt create account: Invalid username or password.");
        response.status(200).json({"Success": false, "Error": "Invalid username or password."});
    }
    else
    {
        const [results2, fields2] = await connection.execute(
            "INSERT INTO Usuarios (NombreUsuario, Contraseña, PuntuaciónMáxima) VALUES (?, ?, 0);",
            [username, password]
            );
            console.log("Succesfully created account!");
            response.status(200).json({"Success": true});
        
    }
    }
    catch (error) {
      response.status(500);
      response.json(error);
  
    }
    finally {
      // The finally statement lets you execute code, after try and catch, regardless of the result. In this case, it closes the connection to the database.
      // Closing the connection is important to avoid memory leaks and to free up resources.
      if (connection !== null) {
        connection.end();
        console.log("Connection closed succesfully!");
      }
    }
  });



//Endpoint para recibir una carta a partir de un id
app.get("/api/card/:id", async (request, response) => {
  let connection = null;

  try {

  connection = await connectToDB();

    // The execute method is used to execute a SQL query. It returns a Promise that resolves with an array containing the results of the query (results) and an array containing the metadata of the results (fields).
    
  const [results, fields] = await connection.execute(
      "SELECT * FROM Cartas WHERE IDCarta = ?;",
      [request.params.id]
  );
      if (results.length < 1)
      {
        response.status(200).send("No se encontro esa carta.");
        return;
      }
      const [stats, fields2] = await connection.execute(
        "SELECT name, health, speed, attack, attackCooldown, `range`, isStructure, attackTowers ,attackEnemies FROM NPC INNER JOIN Cartas USING(IDNPC) WHERE IDCarta = ?;        ",
        [request.params.id]
    );

      delete results[0].IDNPC;
      delete results[0].IDCarta;
      results[0].stats = structuredClone(stats[0])
      
      console.log(results);
      response.status(200).json(results[0]);
      
     

  }
  catch (error) {
    response.status(500);
    response.json(error);
    console.log(error);
  }
  finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});



//Endpoint que regresa los mazos de un jugador
app.get("/api/mazo/:username", async (request, response) => {
  let connection = null;

  try {

  connection = await connectToDB();

    // The execute method is used to execute a SQL query. It returns a Promise that resolves with an array containing the results of the query (results) and an array containing the metadata of the results (fields).
    
  const [mazos, fields] = await connection.execute(
    "SELECT NombreMazo FROM Mazos INNER JOIN Usuarios USING(IDUsuario) WHERE NombreUsuario = ?;",
      [request.params.username]
  );
  if (mazos.length === 0)
  {
   response.status(200).send("No se encontro ese usuario.");
    return;
  }

    for (let i = 0; i < mazos.length; i++)
    {
      //console.log(mazos[i].NombreMazo);
      const [datosmazo, fields2] = await connection.execute(
        "SELECT IDCarta, Cantidad FROM DetallesMazo INNER JOIN Mazos USING(IDMazo) WHERE NombreMazo = ?;",
          [mazos[i].NombreMazo]);

        mazos[i]["Datos"] =[]
        //console.log(datosmazo[0]);
        
        //mazos[i]["Datos"].push( datosmazo[0]) ;
        for (let j = 0; j < datosmazo.length;  j++)
        {
          mazos[i]["Datos"].push( structuredClone(datosmazo[j]) );
        }
    }

    console.log(mazos)//["Datos"][0]);

    //console.log(mazos);

    
     
     
    console.log(mazos);
    response.status(200).json(mazos);
      
     

  }
  catch (error) {
    response.status(500);
    response.json(error);
    console.log(error);
  }
  finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});








  

app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});