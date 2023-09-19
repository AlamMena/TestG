import React, { useEffect, useState } from 'react';

const LogTable = ({logs}) => {


  return (
    <div className="container mx-auto mt-10">
    <div className="overflow-x-auto">
      <table className="min-w-full table-auto">
        <thead>
          <tr>
            <th className="border px-4 py-2">ID</th>
            <th className="border px-4 py-2">Fecha de Solicitud</th>
            <th className="border px-4 py-2">Fecha de Respuesta</th>
            <th className="border px-4 py-2">Código de Estado</th>
            <th className="border px-4 py-2">Usuario</th>
          </tr>
        </thead>
        <tbody>
          {logs.map((log) => (
            <tr key={log.id}>
              <td className="border px-4 py-2">{log.id}</td>
              <td className="border px-4 py-2">{log.requestDate}</td>
              <td className="border px-4 py-2">{log.responseDate}</td>
              <td className="border px-4 py-2">{log.statusCode}</td>
              <td className="border px-4 py-2">{log.user}</td>
            </tr>
          ))}
        </tbody>
      </table>
      </div>
    </div>
  );
};

export default LogTable;
