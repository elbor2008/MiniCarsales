import React from 'react';
import { shallow } from 'enzyme';
import Car from './';
import CarForm from '../../components/car-form';

describe('<Car />', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<Car />);
  });

  it('should have one Link tag', () => {
    expect(wrapper.find('Link').length).toBe(1);
  });

  it('should have one Alert component', () => {
    expect(wrapper.find('Alert').length).toBe(1);
  });

  it('should have one CarForm component', () => {
    expect(wrapper.find(CarForm).length).toBe(1);
  });
});