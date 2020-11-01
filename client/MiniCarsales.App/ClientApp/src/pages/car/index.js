import React, { memo, useState, useEffect, useCallback } from 'react';
import { Link } from 'react-router-dom';
import { Alert } from 'reactstrap';
import { carAgent } from '../../services/request';
import CarList from '../../components/car-list';
import CarForm from '../../components/car-form';

export default memo(() => {
  const [cars, setCars] = useState([]);

  const addCar = useCallback(car => setCars([...cars, car]), [cars]);
  const deleteCar = useCallback(id => setCars(cars.filter(c => c.id !== id)), [cars]);

  useEffect(() => {
    carAgent.getCarList().then(data => {
      setCars(data);
    }).catch(error => { });
  }, []);

  return (
    <>
      <Link to="/" className="badge float-right">go back</Link>
      <div className="clearfix"></div>
      {cars.length === 0 && <Alert color="primary">there is no car available, please create one</Alert>}
      <CarForm addCar={addCar} />
      {cars.length > 0 && <CarList cars={cars} deleteCar={deleteCar} />}
    </>
  );
});