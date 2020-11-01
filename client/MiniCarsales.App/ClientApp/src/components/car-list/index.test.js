import React from 'react';
import { shallow } from 'enzyme';
import CarList from './';
import CarItem from '../car-item';

describe('<CarList />', () => {
  let wrapper;

  beforeEach(() => {
    const cars = [{
      id: '9998a349-ce90-40e7-9d5a-bbcce0b5493c',
      make: 'nissan',
      model: 'x-trail',
      engine: '4-cylinder',
      doors: 4,
      wheels: 4,
      vehicleType: 'Car',
      bodyType: 'SUV'
    }, {
      id: 'ab4cea9a-390a-43e4-90ca-1f3849e2a69c',
      make: 'nissan',
      model: 'x-trail Ti',
      engine: '4-cylinder',
      doors: 4,
      wheels: 4,
      vehicleType: 'Car',
      bodyType: 'SUV'
    }];
    wrapper = shallow(<CarList cars={cars} />);
  });

  it('should have two CarItem components', () => {
    expect(wrapper.find(CarItem).length).toBe(2);
  });
});