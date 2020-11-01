import React from 'react';
import { shallow } from 'enzyme';
import CarItem from './';

describe('<CarItem />', () => {
  let wrapper;

  beforeEach(() => {
    var car = {
      id: '9998a349-ce90-40e7-9d5a-bbcce0b5493c',
      make: 'nissan',
      model: 'x-trail',
      engine: '4-cylinder',
      doors: 4,
      wheels: 4,
      vehicleType: 'Car',
      bodyType: 'SUV'
    };
    wrapper = shallow(<CarItem {...car} />);
  });

  it('should render make', () => {
    expect(wrapper.find('td').at(0).text()).toBe('nissan');
  });

  it('should render model', () => {
    expect(wrapper.find('td').at(1).text()).toBe('x-trail');
  });

  it('should render engine', () => {
    expect(wrapper.find('td').at(2).text()).toBe('4-cylinder');
  });

  it('should render doors', () => {
    expect(wrapper.find('td').at(3).text()).toBe('4');
  });

  it('should render wheels', () => {
    expect(wrapper.find('td').at(4).text()).toBe('4');
  });

  it('should render vehicleType', () => {
    expect(wrapper.find('td').at(5).text()).toBe('Car');
  });

  it('should render bodyType', () => {
    expect(wrapper.find('td').at(6).text()).toBe('SUV');
  });
});