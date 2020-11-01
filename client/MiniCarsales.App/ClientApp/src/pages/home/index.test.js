import React from 'react';
import { shallow } from 'enzyme';
import Home from './';

describe('<Home />', () => {
  let wrapper;

  beforeEach(() => {
    wrapper = shallow(<Home />);
  });

  it('should have one h2 tag', () => {
    expect(wrapper.find('h2').length).toBe(1);
  });

  it('should have one Dropdown component', () => {
    expect(wrapper.find('Dropdown').length).toBe(1);
  });
});