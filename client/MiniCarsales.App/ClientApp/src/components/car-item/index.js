import React, { memo } from 'react';
import { Button } from 'reactstrap';
import { carAgent } from '../../services/request';

export default memo(({ id, make, model, engine, doors, wheels, vehicleType, bodyType, deleteCar }) => {
  const handleDelete = id => {
    carAgent.deleteCar(id).then(() => {
      deleteCar(id);
    }).catch(error => { });
  }

  return (
    <tr>
      <td>{make}</td>
      <td>{model}</td>
      <td>{engine}</td>
      <td>{doors}</td>
      <td>{wheels}</td>
      <td>{vehicleType}</td>
      <td>{bodyType}</td>
      <td><Button color="danger" onClick={() => handleDelete(id)}>Delete</Button></td>
    </tr>
  );
});