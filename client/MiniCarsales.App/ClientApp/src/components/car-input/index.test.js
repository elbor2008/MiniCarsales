import React from 'react';
import { shallow } from 'enzyme';
import CarInput from './';

describe('<CarInput />', () => {
  let wrapper;

  beforeEach(() => {
    const props = {
      label: 'Make',
      type: 'text',
      errorMsg: 'make is mandatory',
      isError: true
    };
    wrapper = shallow(<CarInput {...props} />);
  });

  it('should have one Label component', () => {
    expect(wrapper.find('Label').length).toBe(1);
  });

  it('should have one Input component', () => {
    expect(wrapper.find('Input').length).toBe(1);
  });

  it('should have one FormFeedback component', () => {
    expect(wrapper.find('FormFeedback').length).toBe(1);
  });
});