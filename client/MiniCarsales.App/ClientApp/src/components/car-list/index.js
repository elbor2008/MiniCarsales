import React, { memo } from 'react';
import CarItem from '../car-item';

export default memo(({ cars, deleteCar }) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th>Make</th>
          <th>Model</th>
          <th>Engine</th>
          <th>Doors</th>
          <th>Wheels</th>
          <th>Vehicle Type</th>
          <th>Body Type</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {cars.map(c =>
          <CarItem key={c.id} id={c.id} make={c.make} model={c.model} engine={c.engine} doors={c.doors}
            wheels={c.wheels} vehicleType={c.vehicleType} bodyType={c.bodyType} deleteCar={deleteCar} />
        )}
      </tbody>
    </table>
  );
});