import React from 'react';
import { shallow } from 'enzyme';
import CarForm from './';
import CarInput from '../car-input';

describe('<CarForm />', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<CarForm />);
  });

  it('should have seven CarInput components', () => {
    expect(wrapper.find(CarInput).length).toBe(7);
  });
});