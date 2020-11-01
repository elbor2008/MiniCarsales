import { useState } from 'react';

export default ({
  initValue = '',
  errorMsg = '',
  validator = () => true,
  validateTriggers = ['onChange', 'onBlur'],
  options = undefined
} = {}) => {
  const [value, setValue] = useState(initValue);
  const [isError, setIsError] = useState(false);

  const onChange = e => {
    const { value } = e.target;
    setValue(value);
    if (validateTriggers.includes('onChange')) {
      setIsError(!validator(value));
    }
  };

  const onBlur = e => {
    const { value } = e.target;
    if (validateTriggers.includes('onBlur')) {
      setIsError(!validator(value));
    }
  };

  return {
    value,
    errorMsg,
    isError,
    onChange,
    onBlur,
    options
  };
};