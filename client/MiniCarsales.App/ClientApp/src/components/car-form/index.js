import React, { memo, useMemo } from 'react';
import { Button, Form, FormGroup, Row, Col } from 'reactstrap';
import { isNotEmpty } from '../../utils/validator';
import { doorsOptions, wheelsOptions, vehicleTypeOptions, bodyTypeOptions } from '../../stores/options'
import { carAgent } from '../../services/request';
import useInput from '../../custom-hooks/useInput';
import CarInput from '../car-input';

export default memo(({ addCar }) => {
  const make = useInput({ errorMsg: 'make is required', validator: isNotEmpty });
  const model = useInput({ errorMsg: 'model is required', validator: isNotEmpty });
  const engine = useInput({ errorMsg: 'engine is required', validator: isNotEmpty });
  const doors = useInput({ initValue: doorsOptions[0].value, options: doorsOptions });
  const wheels = useInput({ initValue: wheelsOptions[0].value, options: wheelsOptions });
  const vehicleType = useInput({ initValue: vehicleTypeOptions[0].value, options: vehicleTypeOptions });
  const bodyType = useInput({ initValue: bodyTypeOptions[0].value, options: bodyTypeOptions });

  const isButtonDisabled = useMemo(() => {
    return !make.value || !model.value || !engine.value || make.isError || model.isError || engine.isError;
  }, [make, model, engine]);

  const handleAdd = () => {
    carAgent.addCar({
      make: make.value, model: model.value, engine: engine.value, doors: doors.value,
      wheels: wheels.value, vehicleType: vehicleType.value, bodyType: bodyType.value
    }).then(data => {
      addCar(data);
    }).catch(error => { });
  };

  return (
    <Form>
      <Row form>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Make" type="text" maxLength={20} {...make} />
          </FormGroup>
        </Col>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Model" type="text" maxLength={20} {...model} />
          </FormGroup>
        </Col>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Engine" type="text" maxLength={20} {...engine} />
          </FormGroup>
        </Col>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Doors" type="select" {...doors} />
          </FormGroup>
        </Col>
      </Row>
      <Row form>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Wheels" type="select" {...wheels} />
          </FormGroup>
        </Col>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Vehicle Type" type="select" {...vehicleType} />
          </FormGroup>
        </Col>
        <Col md={3}>
          <FormGroup>
            <CarInput label="Body Type" type="select" {...bodyType} />
          </FormGroup>
        </Col>
      </Row>
      <Button
        className="mb-3"
        disabled={isButtonDisabled}
        onClick={handleAdd}
      >Create</Button>
    </Form >
  );
});